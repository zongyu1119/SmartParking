package com.SmartParking.service.Dao.Mapper;

import com.SmartParking.service.Dao.Models.BC_USER;
import com.SmartParking.service.Dao.SqlCom.BC_USERSql;
import org.apache.ibatis.annotations.*;

import java.util.List;

/**
 * Copyright (C), 1998-2022
 * FileName: BC_USERMapper
 * Author:   WGQ-zy
 * Date:     2022-02-27 15:14
 * Description: 用户表映射关系接口
 */
@Mapper
public interface BC_USERMapper {
    /**
     * 通过用户id查询用户
     * @param id
     * @return
     */
    @Select("SELECT * FROM BC_USER WHERE id=#{id}")
    BC_USER queryById(@Param("id") int id);
    /**
     * 通过用户名查询用户
     * @param username 用户名
     * @return
     */
    @Select("SELECT * FROM BC_USER WHERE username=#{username}")
    BC_USER queryByUserName(@Param("username") String username);

    /**
     * 查询全部用户对象
     * @return 查询结果
     */
    @Select("SELECT * FROM BC_USER")
    List<BC_USER> queryAll();
    /**
     *使用公共的SQL语句构建方法修改数据
     * @param user 用户对象
     * @param condition 条件
     * @return 受影响的条数
     */
    @UpdateProvider(type = BC_USERSql.class,method = "UpdateUser")
    int updateByIdComm(BC_USER user,String condition);

    /**
     * 使用公共的SQL语句构建方法新增数据
     * @param user 用户对象
     * @return 修改的条数
     */
    @InsertProvider(type = BC_USERSql.class,method = "InsertUser")
    int addComm(BC_USER user);

    /**
     * 根据条件查询用户
     * @param user 用户对象
     * @return 一组查询结果
     */
    @SelectProvider(type=BC_USERSql.class,method = "SelectAllUser")
    List<BC_USER> queryByCondition(BC_USER user);
}
