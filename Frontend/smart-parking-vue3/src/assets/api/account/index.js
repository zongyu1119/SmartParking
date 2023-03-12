import request  from "../request";
const baseURL='Account'
/**登录 */
export const login=(data)=>request({method:"post",url:baseURL+'/login',data})
/**获取验证码 */
export const getCaptch=()=>request({method:"get",url:baseURL+'/captch'})