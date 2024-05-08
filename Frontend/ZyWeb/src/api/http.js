import axios from 'axios'
import { ElMessage, ElLoading } from 'element-plus'

const envBaseUrl = import.meta.env.VITE_BASE_URL
// 请求
var instance = axios.create({
  baseURL: envBaseUrl + '/api/',
  timeout: 30000
})
let loadingInstance
// 请求拦截
instance.interceptors.request.use(
  (config) => {
    loadingInstance = ElLoading.service({ fullscreen: true })
    //请求头设置
    let token = localStorage.getItem('token') || ''
    config.headers.Authorization = 'Bearer ' + token
    return config
  },
  (err) => {
    console.log(err)
  }
)
instance.interceptors.response.use(
  (arr) => {
    loadingInstance.close()
    // 对响应码的处理
    switch (arr.status) {
      case 200:
      case 201:
        if (arr.data.isSuccessed) {
          return arr.data.data
        } else {
          ElMessage({
            message: arr.data.message,
            type: 'warning'
          })
        }
        break
      case 401:
        ElMessage({
          message: '请先登录！',
          type: 'warning'
        })
        break
      default:
        ElMessage({
          message: arr.response.data.message,
          type: 'warning'
        })
        break
    }
  },
  (err) => {
    loadingInstance.close()
    console.log(err)
    window.location.href="/login";
    ElMessage({
      message: err.message,
      type: 'error'
    })
  }
)
export { envBaseUrl }
export const get = (url, params) =>
  instance.get(url, {
    params: params
  })
export const post = (url, data) => instance.post(url, data)
export const put = (url, data) => instance.put(url, data)
export const httpdelete = (url, data) =>
  instance.delete(url, {
    data: data
  })
