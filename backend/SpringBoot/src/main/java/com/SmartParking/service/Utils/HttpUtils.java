package com.SmartParking.service.Utils;

import com.SmartParking.service.Common.HttpResult;
import org.json.JSONException;
import org.json.JSONObject;
import org.springframework.web.context.request.RequestContextHolder;
import org.springframework.web.context.request.ServletRequestAttributes;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;

/**
 * Copyright (C), 1998-2022
 * FileName: HttpUtils
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:29
 * Description: HTTP工具类
 */
public class HttpUtils {
    /**
     * 获取HttpServletRequest对象
     * @return
     */
    public static HttpServletRequest getHttpServletRequest() {
        return ((ServletRequestAttributes) RequestContextHolder.getRequestAttributes()).getRequest();
    }

    /**
     * 输出信息到浏览器
     * @param response
     * @param data
     * @throws IOException
     */
    public static void write(HttpServletResponse response, Object data) throws IOException {
        response.setContentType("application/json; charset=utf-8");
        HttpResult result = HttpResult.ok(data);
        String json = null;
        try {
            JSONObject jsonObj=new JSONObject(result);
            json = jsonObj.toString();
            response.getWriter().print(json);
        } catch (JSONException e) {
            e.printStackTrace();
        }
        response.getWriter().flush();
        response.getWriter().close();
    }
}
