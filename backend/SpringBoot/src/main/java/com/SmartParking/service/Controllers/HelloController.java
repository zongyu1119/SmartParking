package com.SmartParking.service.Controllers;

import io.swagger.annotations.Api;
import io.swagger.annotations.ApiOperation;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

/**
 * Copyright (C), 1998-2022
 * FileName: HelloControllor
 * Author:   WGQ-zy
 * Date:     2022-02-26 10:59
 * Description: Hello World!
 */
@Api(tags = "Hello World!")
@Controller
@ResponseBody
@RequestMapping("/hello")
public class HelloController {
    /**
     * 测试方法
     * @return 测试字符串
     */
    @ApiOperation("hello world!")
    @GetMapping("/hello")
    public String HelloWorld(){
        return  "Hello World!";
    }
}
