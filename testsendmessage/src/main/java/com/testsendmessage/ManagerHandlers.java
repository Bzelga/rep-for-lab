package com.testsendmessage;

import org.apache.camel.Exchange;

import java.util.ArrayList;
import java.util.List;

public class ManagerHandlers {
    private List<String> nameHeaders = new ArrayList<>();

    public void AddHeader(Exchange exchange, String nameHeader, Object valueHeader){
        nameHeaders.add(nameHeader);
        exchange.getIn().setHeader(nameHeader, valueHeader);
    }

    public void AddHeaders(Exchange exchange, String[] namesHeaders, Object[]valuesHeader){
        for(int i = 0; i < namesHeaders.length; i++){
            nameHeaders.add(namesHeaders[i]);
            exchange.getIn().setHeader(namesHeaders[i], valuesHeader[i]);
        }
    }

    public void DeleteHeader(Exchange exchange, String nameHeader){
        nameHeaders.remove(nameHeader);
        exchange.getIn().removeHeader(nameHeader);
    }

    public void DeleteHeaders(Exchange exchange){
        for (String nameHandlers: nameHeaders) {
            exchange.getIn().removeHeader(nameHandlers);
        }
    }
}
