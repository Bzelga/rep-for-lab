package com.testsendmessage;

import com.fasterxml.jackson.annotation.JsonProperty;

public class ConfigFileModel {
	
	@JsonProperty("IpServer")
	private String ipServer;
	
	public String getIpServer() {
		return ipServer;
	}
	
	public void setIpServer(String ipServer) {
		this.ipServer = ipServer;
	}
}
