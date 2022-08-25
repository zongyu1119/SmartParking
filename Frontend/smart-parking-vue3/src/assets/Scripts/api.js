import request  from "./request";
/**
 * 登录
 * @param {*} data 登录参数
 * @returns 
 */
export const login=(data)=>request({method:"post",url:"Login/login",data});
/**
 * 获得当前登录用户的信息
 * @returns 
 */
export const GetUserDetailInfoToView=()=>request({method:"get",url:"Login/GetUserDetailInfoToView"})
