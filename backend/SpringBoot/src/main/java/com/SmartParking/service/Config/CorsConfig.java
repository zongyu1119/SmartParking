package com.SmartParking.service.Config;

import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

/**
 * Copyright (C), 1998-2022
 * FileName: CorsConfig
 * Author:   WGQ-zy
 * Date:     2022-02-26 23:22
 * Description: 跨域配置类
 */
@Configuration
public class CorsConfig implements WebMvcConfigurer {
    @Override
    public void addCorsMappings(CorsRegistry registry) {
        registry.addMapping("/**")    // 允许跨域访问的路径
               // .allowedOrigins("*")    // 允许跨域访问的源
                .allowedMethods("POST", "GET", "PUT", "OPTIONS", "DELETE")    // 允许请求方法
                .maxAge(168000)    // 预检间隔时间
                .allowedHeaders("*")  // 允许头部设置
                .allowedOriginPatterns("*")
                .allowCredentials(true);    // 是否发送cookie
    }
}
