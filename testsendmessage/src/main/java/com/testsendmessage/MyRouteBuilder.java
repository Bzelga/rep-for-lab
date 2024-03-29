package com.testsendmessage;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.apache.camel.builder.RouteBuilder;
import org.apache.camel.model.dataformat.JsonLibrary;

import java.io.File;
import java.io.FileOutputStream;
import java.util.ArrayList;
import java.util.Base64;
import java.util.List;

public class MyRouteBuilder extends RouteBuilder {
    public void configure() {
        List<ReturnModel> returnModels = new ArrayList<>();
        ObjectMapper mapper = new ObjectMapper();
        ManagerHandlers managerHandlers = new ManagerHandlers();

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

        restConfiguration().component("jetty").port(8082);

        from("rest:post:fz44")
            .unmarshal().json(JsonLibrary.Jackson, PostModels.class)
            .process(exchange -> {
                PostModels postModels = exchange.getIn().getBody(PostModels.class);

                managerHandlers.AddHeaders(exchange,
                    new String[]{"Auth","JsonDate", "Size", "Range", "Name"},
                    new Object[]{postModels.getAuth(),
                        "\""+mapper.writeValueAsString(postModels.getJsonDate()).replaceAll("\"","'")+"\"",
                        postModels.getJsonDate().getSize(),
                        "0-"+(postModels.getJsonDate().getSize() - 1),
                            postModels.getJsonDate().getName()
                });

                File txtFile = new File("src/shell/"+postModels.getJsonDate().getName());

                try(FileOutputStream fos = new FileOutputStream(txtFile)){
                    byte[] decoder = Base64.getDecoder().decode(postModels.getFileBase64());
                    fos.write(decoder);
                }
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
                        "${header.Size} ${header.Range}/${header.Size} src/shell/${header.Name}")
                            .process(exchange -> {
                                String[] wordsResult = exchange.getIn().getBody(String.class).split("\n");

                                exchange.getIn().setHeader("HttpCode", wordsResult[0].split(" ")[1]);

                                managerHandlers.DeleteHeader(exchange, "Range");

                                returnModels.add(new ReturnModel(wordsResult[0].split(" ")[1],
                                        wordsResult[wordsResult.length-1]));

                                File txtFile = new File("src/shell/" + exchange.getIn().getHeader("Name"));
                                txtFile.delete();
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
                                                returnModels.clear();
                                            })
                                    .otherwise()
                                        .process(exchange -> {
                                            exchange.getIn().setBody(mapper.writeValueAsString(returnModels));

                                            managerHandlers.DeleteHeaders(exchange);
                                            returnModels.clear();
                                    }).endChoice()
                            .otherwise()
                                .process(exchange -> {
                                    exchange.getIn().setBody(mapper.writeValueAsString(returnModels));

                                    managerHandlers.DeleteHeaders(exchange);
                                    returnModels.clear();
                                }).endChoice()
                    .otherwise()
                        .process(exchange -> {
                            exchange.getIn().setBody(mapper.writeValueAsString(returnModels));

                            managerHandlers.DeleteHeaders(exchange);
                            returnModels.clear();
                        }).endChoice();
    }
}
