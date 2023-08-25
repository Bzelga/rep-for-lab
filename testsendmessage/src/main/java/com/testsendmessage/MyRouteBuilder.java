package com.testsendmessage;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.camel.builder.RouteBuilder;
import org.apache.camel.model.dataformat.JsonLibrary;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;

public class MyRouteBuilder extends RouteBuilder {
    public void configure() throws FileNotFoundException, IOException {
        List<ReturnModel> returnModels = new ArrayList<>();
        ObjectMapper mapper = new ObjectMapper();
        ManagerHandlers managerHandlers = new ManagerHandlers();
        ConfigFileModel configFileModel = new ConfigFileModel();
        
        InputStream is = ConfigFileModel.class.getResourceAsStream("/config.json");
        configFileModel = mapper.readValue(is, ConfigFileModel.class);
//          Заккоментированный следующий код - это что бы использовать https для сервиса, для этого нужно сделать
//        Сертефикат и хранилище ключей
//
//        KeyStoreParameters ksp = new KeyStoreParameters();
//        ksp.setResource("file:/home/bzelga/dev/keystore.jks");
//        ksp.setPassword("mypassword");
//
//        KeyManagersParameters kmp = new KeyManagersParameters();
//        kmp.setKeyStore(ksp);
//        kmp.setKeyPassword("mypassword");
//
//        SSLContextParameters scp = new SSLContextParameters();
//        scp.setKeyManagers(kmp);
//
//        JettyHttpComponent  jettyComponent = getContext().getComponent("jetty", JettyHttpComponent .class);
//        jettyComponent.setSslContextParameters(scp);
//        restConfiguration().component("jetty").scheme("https").host("exampleaddress.ru").port(8082);

        restConfiguration().component("jetty").scheme("http").host(configFileModel.getIpServer()).port(8082);

        from("rest:post:fz44")
            .unmarshal().json(JsonLibrary.Jackson, PostModels.class)
            .process(exchange -> {
                PostModels postModels = exchange.getIn().getBody(PostModels.class);

                managerHandlers.AddHeaders(exchange,
                    new String[]{"Auth","JsonDate", "Size", "Range"},
                    new Object[]{postModels.getAuth(),
                        "\""+mapper.writeValueAsString(postModels.getJsonDate()).replaceAll("\"","'")+"\"",
                        postModels.getJsonDate().getSize(),
                        "0-"+(postModels.getJsonDate().getSize() - 1)
                });
            })
            .toD("exec:src/shell/1.sh?args=${header.Auth} ${header.JsonDate}")
                .process(exchange -> {
                    String[] wordsResult = exchange.getIn().getBody(String.class).split("\n");

                    StartSessionModel startSessionModel = mapper.readValue(wordsResult[wordsResult.length-1], StartSessionModel.class);

                    managerHandlers.AddHeaders(exchange,
                    new String[]{"HttpCode", "FileContentId"},
                    new Object[]{wordsResult[0].split(" ")[1], startSessionModel.getFileContentId()});

                    managerHandlers.DeleteHeader(exchange, "JsonDate");

                    returnModels.add(new ReturnModel(wordsResult[0].split(" ")[1], wordsResult[wordsResult.length-1]));
                })
                .choice()
                    .when(simple("${header.HttpCode} < 300"))
                        .toD("exec:src/shell/2.sh?args=${header.FileContentId} " +
                        "${header.Auth} "+
                        "${header.Size} ${header.Range}/${header.Size} src/shell/minifile.txt")
                            .process(exchange -> {
                                String[] wordsResult = exchange.getIn().getBody(String.class).split("\n");

                                exchange.getIn().setHeader("HttpCode", wordsResult[0].split(" ")[1]);

                                managerHandlers.DeleteHeader(exchange, "Range");

                                returnModels.add(new ReturnModel(wordsResult[0].split(" ")[1],
                                        wordsResult[wordsResult.length-1]));
                            })
                            .choice()
                                .when(simple("${header.HttpCode} < 300"))
                                .toD("exec:src/shell/3.sh?args=${header.FileContentId} " +
                                "${header.Auth} "+
                                "${header.Size}")
                                    .process(exchange -> {
                                        String[] wordsResult = exchange.getIn().getBody(String.class).split("\n");

                                        exchange.getIn().setHeader("HttpCode", wordsResult[0].split(" ")[1]);

                                        managerHandlers.DeleteHeader(exchange, "Size");

                                        returnModels.add(new ReturnModel(wordsResult[0].split(" ")[1],
                                                wordsResult[wordsResult.length-1]));
                                    })
                                    .choice()
                                        .when(simple("${header.HttpCode} < 300"))
                                        .toD("exec:src/shell/4.sh?args=${header.FileContentId} " +
                                        "${header.Auth}")
                                            .process(exchange -> {
                                                String[] wordsResult = exchange.getIn().getBody(String.class).split("\n");

                                                exchange.getIn().setHeader("HttpCode", wordsResult[0].split(" ")[1]);

                                                managerHandlers.DeleteHeaders(exchange);

                                                returnModels.add(new ReturnModel(wordsResult[0].split(" ")[1],
                                                        wordsResult[wordsResult.length-1]));
                                                exchange.getIn().setBody(mapper.writeValueAsString(returnModels));
                                            })
                                    .otherwise()
                                        .process(exchange -> {
                                            exchange.getIn().setBody(mapper.writeValueAsString(returnModels));

                                            managerHandlers.DeleteHeaders(exchange);
                                    }).endChoice()
                            .otherwise()
                                .process(exchange -> {
                                    exchange.getIn().setBody(mapper.writeValueAsString(returnModels));

                                    managerHandlers.DeleteHeaders(exchange);
                                }).endChoice()
                    .otherwise()
                        .process(exchange -> {
                            exchange.getIn().setBody(mapper.writeValueAsString(returnModels));

                            managerHandlers.DeleteHeaders(exchange);
                        }).endChoice();
    }
}
