package com.SmartParking.service.Controllers;

import com.SmartParking.service.Common.HttpResult;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Copyright (C), 1998-2022
 * FileName: UserController
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:20
 * Description: UserController
 */
@Api(tags = "用户接口")
@RestController
@RequestMapping("user")
public class UserController {
    @ApiOperation("查找所有用户")
    @PreAuthorize("hasAuthority('sys:user:view')")
    @GetMapping(value="/findAll")
    public HttpResult findAll() {
        return HttpResult.ok("查找用户方法执行成功！");
    }
    @ApiOperation("编辑用户")
    @PreAuthorize("hasAuthority('sys:user:edit')")
    @GetMapping(value="/edit")
    public HttpResult edit() {
        return HttpResult.ok("编辑用户方法执行成功！");
    }

    @ApiOperation("删除用户")
    @PreAuthorize("hasAuthority('sys:user:delete')")
    @GetMapping(value="/delete")
    public HttpResult delete() {
        return HttpResult.ok("删除用户方法执行成功！");
    }
}
