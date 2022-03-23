package com.SmartParking.service.Models;

/**
 * Copyright (C), 1998-2022
 * FileName: User
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:17
 * Description: User用户对象
 */
public class User {
    private Long id;

    private String username;

    private String password;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
