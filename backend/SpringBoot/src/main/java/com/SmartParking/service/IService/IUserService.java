package com.SmartParking.service.IService;

import com.SmartParking.service.Models.User;

import java.util.Set;

/**
 * Copyright (C), 1998-2022
 * FileName: UserService
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:18
 * Description: 用户管理接口
 */
public interface IUserService {
    /**
     * 根据用户名查找用户
     * @param username
     * @return
     */
    User findByUsername(String username);

    /**
     * 查找用户的菜单权限标识集合
     * @param username
     * @return
     */
    Set<String> findPermissions(String username);
}
