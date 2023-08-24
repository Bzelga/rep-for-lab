package com.testsendmessage;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PostModels {
    @JsonProperty("auth")
    private String Auth;
    @JsonProperty("jsonDate")
//    private String JsonDate;
    private JsonDateModel jsonDateModel;

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
}
