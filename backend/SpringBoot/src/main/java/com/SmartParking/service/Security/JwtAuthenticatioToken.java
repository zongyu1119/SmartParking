package com.SmartParking.service.Security;

import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.GrantedAuthority;

import java.util.Collection;

/**
 * Copyright (C), 1998-2022
 * FileName: JwtAuthenticatioToken
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:25
 * Description: 自定义令牌对象
 */
public class JwtAuthenticatioToken extends UsernamePasswordAuthenticationToken {
    private static final long serialVersionUID = 1L;

    private String token;

    public JwtAuthenticatioToken(Object principal, Object credentials){
        super(principal, credentials);
    }

    public JwtAuthenticatioToken(Object principal, Object credentials, String token){
        super(principal, credentials);
        this.token = token;
    }

    public JwtAuthenticatioToken(Object principal, Object credentials, Collection<? extends GrantedAuthority> authorities, String token) {
        super(principal, credentials, authorities);
        this.token = token;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public static long getSerialversionuid() {
        return serialVersionUID;
    }
}
