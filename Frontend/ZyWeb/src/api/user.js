import { get } from './http'
export const getUserList = (data) => get('user/getList', data)
export const getChatGroup = () => get('/user/getChatGroup')
export const getFirends = (data) => get('/user/getFirend', data)
