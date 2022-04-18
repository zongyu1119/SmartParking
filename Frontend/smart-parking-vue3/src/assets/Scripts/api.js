import request  from "./request";
export const login=(data)=>request({method:"post",url:"Login/login",data})
