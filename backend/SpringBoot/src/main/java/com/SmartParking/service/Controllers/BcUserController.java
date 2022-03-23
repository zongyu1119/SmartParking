package com.SmartParking.service.Controllers;

import com.SmartParking.service.Common.HttpResult;
import com.SmartParking.service.Dao.Mapper.BC_USERMapper;
import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

/**
 * Copyright (C), 1998-2022
 * FileName: BcUserController
 * Author:   WGQ-zy
 * Date:     2022-02-27 16:41
 * Description: 用户管理API
 */
@Api(tags = "用户管理API")
@RestController
@RequestMapping("BC_USER")
public class BcUserController {
    @Autowired
    BC_USERMapper userMapper;
    @ApiOperation("查找所有用户")
    @PreAuthorize("hasAuthority('sys:user:view')")//有这个权限的就可以访问
    @GetMapping(value="/findAll")
    public HttpResult findAll() {
        return HttpResult.ok(userMapper.queryAll());
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
