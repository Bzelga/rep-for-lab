package com.testsendmessage;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PostModels {
    @JsonProperty("auth")
    private String Auth;
    @JsonProperty("jsonDate")
    private JsonDateModel jsonDateModel;
    @JsonProperty("fileBase64")
    private String fileBase64;

    public PostModels(){
    }

    public void setAuth(String auth){
        Auth = auth;
    }

    public String getAuth(){
        return Auth;
    }

    public void setJsonDate(JsonDateModel jsonDateModel) {
        this.jsonDateModel = jsonDateModel;
    }

    public JsonDateModel getJsonDate() {
        return jsonDateModel;
    }

    public String getFileBase64(){return fileBase64;}

    public void setFileBase64(String fileBase64){this.fileBase64 = fileBase64;}
}
