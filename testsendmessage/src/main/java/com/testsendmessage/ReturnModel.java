package com.testsendmessage;

public class ReturnModel {
    public  ReturnModel(String returnCode, String returnBody){
        this.returnBody = returnBody;
        this.returnCode = returnCode;
    }

    private String returnCode;

    private String returnBody;

    public String getReturnCode(){
        return returnCode;
    }

    public void setReturnCode(String returnCode){
        this.returnCode = returnCode;
    }

    public String getReturnBody(){
        return returnBody;
    }

    public void setReturnBody(String returnBody){
        this.returnBody = returnBody;
    }
}
