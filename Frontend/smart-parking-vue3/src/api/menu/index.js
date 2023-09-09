import request from "../request";
const baseURL = 'usr/Menu'
/**
 * 新增菜单
 * @param {*} data 
 * @returns 
 */
export const create = (data) => request({ method: "post", url: baseURL, data })
/**
 * 查询菜单
 * @param {*} params 
 * @returns 
 */
export const get = (params) => request({ method: 'get', url: baseURL, params: params })