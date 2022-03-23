package com.SmartParking.service.Service;

import com.SmartParking.service.Dao.Mapper.BC_USERMapper;
import com.SmartParking.service.Dao.Models.BC_USER;
import com.SmartParking.service.IService.IUserService;
import com.SmartParking.service.Models.User;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.HashSet;
import java.util.Set;

/**
 * Copyright (C), 1998-2022
 * FileName: SysUserServiceImpl
 * Author:   WGQ-zy
 * Date:     2022-02-27 00:19
 * Description: SysUserServiceImpl
 */
@Service
public class SysUserServiceImpl implements IUserService {
    @Autowired
    BC_USERMapper userMapper;

    /**
     * 根据用户名查询用户的信息
     * @param username
     * @return 用户信息
     */
    @Override
    public User findByUsername(String username) {
        BC_USER bcUser=userMapper.queryByUserName(username);
        if(bcUser!=null) {
            User user = new User();
            user.setId(Long.valueOf(bcUser.getId()));
            user.setUsername(username);
            String password = new BCryptPasswordEncoder().encode(bcUser.getPassword());
            user.setPassword(password);
            return  user;
        }
        return null;
    }

    /**
     * 根据用户名返回用户的权限列表
     * @param username 用户名
     * @return 权限列表
     */
    @Override
    public Set<String> findPermissions(String username) {
        //临时先直接给权限，后期需要根据数据库配置对权限重新给定
        Set<String> permissions = new HashSet<>();
        permissions.add("sys:user:view");
        permissions.add("sys:user:add");
        permissions.add("sys:user:edit");
        permissions.add("sys:user:delete");
        return permissions;
    }
}
