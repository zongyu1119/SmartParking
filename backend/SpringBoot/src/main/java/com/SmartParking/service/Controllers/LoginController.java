package com.SmartParking.service.Controllers;

import com.SmartParking.service.Common.HttpResult;
import com.SmartParking.service.Common.LoginBean;
import com.SmartParking.service.Security.JwtAuthenticatioToken;
import com.SmartParking.service.Utils.SecurityUtils;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import javax.servlet.http.HttpServletRequest;
import java.io.IOException;

/**
 * Copyright (C), 1998-2022
 * FileName: LoginController
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:01
 * Description: 登录控制器
 */
@Api(tags = "登录")
@RestController
@Slf4j//lombok打印日志
public class LoginController {
    @Autowired
    private AuthenticationManager authenticationManager;

    /**
     * 登录接口
     */
    @ApiOperation("登录接口")
    @PostMapping(value = "/login")
    public HttpResult login(@RequestBody LoginBean loginBean, HttpServletRequest request) throws IOException {
        String username = loginBean.getUsername();
        String password = loginBean.getPassword();
        log.info("Login username:{};",username);
        // 系统登录认证
        JwtAuthenticatioToken token = SecurityUtils.login(request, username, password, authenticationManager);

        return HttpResult.ok(token);
    }
}
