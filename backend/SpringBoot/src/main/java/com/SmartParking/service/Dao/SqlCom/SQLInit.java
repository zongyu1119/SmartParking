package com.SmartParking.service.Dao.SqlCom;

import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Copyright (C), 1998-2021
 * FileName: SQLInit
 * Author:   WGQ-zy
 * Date:     2021-08-11 21:48
 * Description: SQL语句初始化
 */
public class SQLInit {
    /***
     * 获得Insert语句
     * @param object
     * @return
     * @throws Exception
     */
    public static String getInsertStr(Object object)throws Exception {
        if (object != null) {
            StringBuilder sql = new StringBuilder();
            // 拿到该类
            Class<?> clz = object.getClass();
            sql.append("INSERT INTO " + clz.getSimpleName());
            StringBuilder sqlkey = new StringBuilder();
            StringBuilder sqlvalue = new StringBuilder();
           // System.out.println(clz.getSimpleName());
            // 获取实体类的所有属性，返回Field数组
            Field[] fields = clz.getDeclaredFields();
            for (Field field : fields) {
                //System.out.println(field.getGenericType());//打印该类的所有属性类型
                // 如果类型是String
                if (field.getGenericType().toString().equals(
                        "class java.lang.String")) { // 如果type是类类型，则前面包含"class "，后面跟类名
                    // 拿到该属性的gettet方法
                    /**
                     * 这里需要说明一下：他是根据拼凑的字符来找你写的getter方法的
                     * 在Boolean值的时候是isXXX（默认使用ide生成getter的都是isXXX）
                     * 如果出现NoSuchMethod异常 就说明它找不到那个gettet方法 需要做个规范
                     */
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    //System.out.println("String type name:" + field.getName());
                    String val = (String) m.invoke(object);// 调用getter方法获取属性值
                    if (val != null) {
                        // System.out.println("String type:" + val);
                        sqlkey.append(field.getName());
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlkey.append(",");
                        sqlvalue.append(",");
                    }

                } // 如果类型是Integer
                if (field.getGenericType().toString().equals(
                        "class java.lang.Integer")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Integer val = (Integer) m.invoke(object);
                    if (val != null) {
                        // System.out.println("Integer type:" + val);
                        sqlkey.append(field.getName());
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlkey.append(",");
                        sqlvalue.append(",");
                    }

                }

                // 如果类型是Double
                if (field.getGenericType().toString().equals(
                        "class java.lang.Double")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Double val = (Double) m.invoke(object);
                    if (val != null) {
                        //System.out.println("Double type:" + val);
                        sqlkey.append(field.getName());
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlkey.append(",");
                        sqlvalue.append(",");
                    }

                }

                // 如果类型是Boolean 是封装类
                if (field.getGenericType().toString().equals(
                        "class java.lang.Boolean")) {
                    Method m = (Method) object.getClass().getMethod(
                            field.getName());
                    Boolean val = (Boolean) m.invoke(object);
                    if (val != null) {
                        //System.out.println("Boolean type:" + val);
                        sqlkey.append(field.getName());
                        sqlvalue.append("'");
                        sqlvalue.append(val ? '1' : "0");
                        sqlvalue.append("'");
                        sqlkey.append(",");
                        sqlvalue.append(",");
                    }

                }

                // 如果类型是boolean 基本数据类型不一样 这里有点说名如果定义名是 isXXX的 那就全都是isXXX的
                // 反射找不到getter的具体名
                if (field.getGenericType().toString().equals("boolean")) {
                    Method m = (Method) object.getClass().getMethod(
                            field.getName());
                    Boolean val = (Boolean) m.invoke(object);
                    if (val != null) {
                        //System.out.println("boolean type:" + val);
                        sqlkey.append(field.getName());
                        sqlvalue.append("'");
                        sqlvalue.append(val ? '1' : "0");
                        sqlvalue.append("'");
                        sqlkey.append(",");
                        sqlvalue.append(",");
                    }

                }
                // 如果类型是Date
                if (field.getGenericType().toString().equals(
                        "class java.util.Date")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Date val = (Date) m.invoke(object);
                    if (val != null) {
                        //System.out.println("Date type:" + val);
                        sqlkey.append(field.getName());
                        sqlvalue.append("'");
                        DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                        sqlvalue.append(dateFormat.format(val));
                        sqlvalue.append("'");
                        sqlkey.append(",");
                        sqlvalue.append(",");
                    }

                }
                // 如果类型是Short
                if (field.getGenericType().toString().equals(
                        "class java.lang.Short")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Short val = (Short) m.invoke(object);
                    if (val != null) {
                        //System.out.println("Short type:" + val);
                        sqlkey.append(field.getName());
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlkey.append(",");
                        sqlvalue.append(",");
                    }

                }
                // 如果还需要其他的类型请自己做扩展

            }
            if(sqlkey.length()>0){
              sql.append("(");
              sql.append(sqlkey.substring(0,sqlkey.length()-1));
              sql.append(")");
              sql.append(" VALUE");
                sql.append("(");
                sql.append(sqlvalue.substring(0,sqlvalue.length()-1));
                sql.append(")");
            }
            return sql.toString();
        }
        return null;
    }
    /***
     * 获得Update语句
     * @param object
     * @return
     * @throws Exception
     */
    public static String getUpdateStr(Object object,String condition)throws Exception {
        if (object != null) {
            StringBuilder sqlvalue = new StringBuilder();
            StringBuilder sql = new StringBuilder();
            // 拿到该类
            Class<?> clz = object.getClass();
            sql.append("UPDATE " + clz.getSimpleName()+" SET ");
            // 获取实体类的所有属性，返回Field数组
            Field[] fields = clz.getDeclaredFields();
            for (Field field : fields) {
                // 如果类型是String
                if (field.getGenericType().toString().equals(
                        "class java.lang.String")) { // 如果type是类类型，则前面包含"class "，后面跟类名
                    // 拿到该属性的getter方法
                    /**
                     * 这里需要说明一下：他是根据拼凑的字符来找你写的getter方法的
                     * 在Boolean值的时候是isXXX（默认使用ide生成getter的都是isXXX）
                     * 如果出现NoSuchMethod异常 就说明它找不到那个gettet方法 需要做个规范
                     */
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    String val = (String) m.invoke(object);// 调用getter方法获取属性值
                    if (val != null) {
                        sqlvalue.append(field.getName());
                        sqlvalue.append("=");
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlvalue.append(",");
                    }
                } // 如果类型是Integer
                if (field.getGenericType().toString().equals(
                        "class java.lang.Integer")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Integer val = (Integer) m.invoke(object);
                    if (val != null) {
                        sqlvalue.append(field.getName());
                        sqlvalue.append("=");
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlvalue.append(",");
                    }
                }
                // 如果类型是Double
                if (field.getGenericType().toString().equals(
                        "class java.lang.Double")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Double val = (Double) m.invoke(object);
                    if (val != null) {
                        sqlvalue.append(field.getName());
                        sqlvalue.append("=");
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlvalue.append(",");
                    }
                }
                // 如果类型是Boolean 是封装类
                if (field.getGenericType().toString().equals(
                        "class java.lang.Boolean")) {
                    Method m = (Method) object.getClass().getMethod(
                            field.getName());
                    Boolean val = (Boolean) m.invoke(object);
                    if (val != null) {
                        sqlvalue.append(field.getName());
                        sqlvalue.append("=");
                        sqlvalue.append("'");
                        sqlvalue.append(val ? '1' : "0");
                        sqlvalue.append("'");
                        sqlvalue.append(",");
                    }
                }
                // 如果类型是boolean 基本数据类型不一样 这里有点说名如果定义名是 isXXX的 那就全都是isXXX的
                // 反射找不到getter的具体名
                if (field.getGenericType().toString().equals("boolean")) {
                    Method m = (Method) object.getClass().getMethod(
                            field.getName());
                    Boolean val = (Boolean) m.invoke(object);
                    if (val != null) {
                        sqlvalue.append(field.getName());
                        sqlvalue.append("=");
                        sqlvalue.append("'");
                        sqlvalue.append(val ? '1' : "0");
                        sqlvalue.append("'");
                        sqlvalue.append(",");
                    }

                }
                // 如果类型是Date
                if (field.getGenericType().toString().equals(
                        "class java.util.Date")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Date val = (Date) m.invoke(object);
                    if (val != null) {
                        DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
                        sqlvalue.append(field.getName());
                        sqlvalue.append("=");
                        sqlvalue.append("'");
                        sqlvalue.append(dateFormat.format(val));
                        sqlvalue.append("'");
                        sqlvalue.append(",");
                    }

                }
                // 如果类型是Short
                if (field.getGenericType().toString().equals(
                        "class java.lang.Short")) {
                    Method m = (Method) object.getClass().getMethod(
                            "get" + getMethodName(field.getName()));
                    Short val = (Short) m.invoke(object);
                    if (val != null) {
                        sqlvalue.append(field.getName());
                        sqlvalue.append("=");
                        sqlvalue.append("'");
                        sqlvalue.append(val);
                        sqlvalue.append("'");
                        sqlvalue.append(",");
                    }

                }
                // 如果还需要其他的类型请自己做扩展

            }
            if(sqlvalue.length()>0){
                sql.append(sqlvalue.substring(0,sqlvalue.length()-1));
            }
            sql.append(" WHERE ");
            sql.append(condition);
            return sql.toString();
        }
        return null;
    }
    // 把一个字符串的第一个字母大写、效率是最高的、
    private static String getMethodName(String fildeName) throws Exception {
        byte[] items = fildeName.getBytes();
        items[0] = (byte) ((char) items[0] - 'a' + 'A');
        return new String(items);
    }
}
