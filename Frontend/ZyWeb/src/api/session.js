import { post } from './http'
export const login = (data) => post('Session/Login', data)
