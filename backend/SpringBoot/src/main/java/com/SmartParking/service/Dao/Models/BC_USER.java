package com.SmartParking.service.Dao.Models;

import lombok.Data;

/**
 * Copyright (C), 1998-2022
 * FileName: BC_USER
 * Author:   WGQ-zy
 * Date:     2022-02-27 15:03
 * Description: 用户表
 */
@Data
public class BC_USER {
    /** ID */
    private Integer id ;
    /** 用户名 */
    private String username ;
    /** 密码 */
    private String password ;
    /** 角色 */
    private Integer role ;
    /** 状态（0:不可用;1:可用;） */
    private Integer state ;
}
