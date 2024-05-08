import { get } from './http'
export const getNewMessage = (data) => get('message/getNewMessage', data)
