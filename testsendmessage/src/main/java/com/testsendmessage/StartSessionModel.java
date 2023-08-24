package com.testsendmessage;

import com.fasterxml.jackson.annotation.JsonProperty;

public class StartSessionModel {
    @JsonProperty("file_content_id")
    private String fileContentId;

    public String getFileContentId(){
        return fileContentId;
    }

    public void setFileContentId(String fileContentId){
        this.fileContentId = fileContentId;
    }
}
