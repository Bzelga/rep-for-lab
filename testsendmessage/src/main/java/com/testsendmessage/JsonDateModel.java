package com.testsendmessage;

public class JsonDateModel {
    private String name;
    private int size;
    private String digest;

    public String getName(){
        return name;
    }

    public void setName(String name){
        this.name = name;
    }

    public int getSize(){
        return size;
    }

    public void setSize(int size){
        this.size = size;
    }

    public String getDigest(){
        return digest;
    }

    public void setDigest(String digest){
        this.digest = digest;
    }
}
