package com.SmartParking.service.Config;

import io.swagger.annotations.ApiOperation;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import springfox.documentation.builders.ApiInfoBuilder;
import springfox.documentation.builders.PathSelectors;
import springfox.documentation.builders.RequestHandlerSelectors;
import springfox.documentation.service.*;
import springfox.documentation.spi.DocumentationType;
import springfox.documentation.spi.service.contexts.SecurityContext;
import springfox.documentation.spring.web.plugins.Docket;

import java.util.Collections;


/**
 * Copyright (C), 1998-2022
 * FileName: SwaggerConfig
 * Author:   WGQ-zy
 * Date:     2022-02-27 01:07
 * Description: SwaggerConfig配置类 swagger3访问地址http://localhost:port/swagger-ui/index.html
 */
@Configuration
public class SwaggerConfig {
    @Bean
    public Docket createRestApi(){
        return new Docket(DocumentationType.OAS_30)
                .apiInfo(apiInfo())

                .securitySchemes(Collections.singletonList(HttpAuthenticationScheme.JWT_BEARER_BUILDER
                //显示用
                        .name("JWT")
                        .build()))
                .securityContexts(Collections.singletonList(SecurityContext.builder()
                                .securityReferences(Collections.singletonList(SecurityReference.builder()
                                        .scopes(new AuthorizationScope[0])
                                        .reference("JWT")
                                        .build()))
                                // 声明作用域
                                .operationSelector(o -> o.requestMappingPattern().matches("/.*"))
                        .build()))
                .select()
                .apis(RequestHandlerSelectors.withMethodAnnotation(ApiOperation.class))
                .paths(PathSelectors.any())
                .build();
    }

    /**
     * API接口信息
     * @return
     */
    private ApiInfo apiInfo(){
        return new ApiInfoBuilder()
                .title("SmartParking Swagger3接口文档")
                .description("SmartParking 接口文档。")
                .contact(new Contact("zy。", "https://gitee.com/zongyu1119", "wuguoqiang0927@hotmail.com"))
                .version("0.1")
                .build();
    }
}
