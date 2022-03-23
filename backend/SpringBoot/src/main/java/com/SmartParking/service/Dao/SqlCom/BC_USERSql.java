package com.SmartParking.service.Dao.SqlCom;

import com.SmartParking.service.Dao.Models.BC_USER;
import org.apache.ibatis.jdbc.SQL;

/**
 * Copyright (C), 1998-2021
 * FileName: UserSql
 * Author:   WGQ-zy
 * Date:     2021-08-07 12:35
 * Description: 用户自定义的sql语句
 */
public class BC_USERSql {
    /**
     * 新增用户的SQL语句
     * @param user
     * @return
     * @throws Exception
     */
    public String InsertUser(BC_USER user) throws Exception{
        return com.SmartParking.service.Dao.SqlCom.SQLInit.getInsertStr(user);
    }

    /**
     * 修改用户的SQL语句
     * @param user
     * @param condition
     * @return
     * @throws Exception
     */
    public String UpdateUser(BC_USER user,String condition) throws Exception{
            return com.SmartParking.service.Dao.SqlCom.SQLInit.getUpdateStr(user,condition);
    }

    /**
     * 查询用户的SQL语句
     * @param user
     * @return
     * @throws Exception
     */
    public String SelectAllUser(BC_USER user) throws Exception{
        return new SQL(){
            {
                SELECT("*");
                FROM("BC_USER");
                StringBuilder condition=new StringBuilder();
                if(user.getId()!=0){
                    condition.append("id='"+user.getId()+"'");
                }else {
                    if(user.getUsername()!=null){
                        condition.append("name='"+user.getUsername()+"'");
                    }
                    if(user.getUsername()!=null){
                        condition.append((condition.length()>0?" and ":"")+ "username='"+user.getUsername()+"'");
                    }
                    if(user.getRole()!=null){
                        condition.append((condition.length()>0?" and ":"")+ "role='"+user.getRole()+"'");
                    }
                    if(user.getClass()!=null){
                        condition.append((condition.length()>0?" and ":"")+ "class='"+user.getClass()+"'");
                    }
                }
                WHERE(condition.toString());
            }
        }.toString();

    }
}
