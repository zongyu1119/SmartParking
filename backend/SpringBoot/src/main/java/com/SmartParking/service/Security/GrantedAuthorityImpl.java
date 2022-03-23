package com.SmartParking.service.Security;

import org.springframework.security.core.GrantedAuthority;

/**
 * Copyright (C), 1998-2022
 * FileName: GrantedAuthorityImpl
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:46
 * Description: 权限封装
 */
public class GrantedAuthorityImpl implements GrantedAuthority {

    private static final long serialVersionUID = 1L;

    private String authority;

    public GrantedAuthorityImpl(String authority) {
        this.authority = authority;
    }

    public void setAuthority(String authority) {
        this.authority = authority;
    }

    @Override
    public String getAuthority() {
        return this.authority;
    }
}
