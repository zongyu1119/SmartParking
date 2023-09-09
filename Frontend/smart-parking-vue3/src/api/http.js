import axios from 'axios'
import { ElMessage,ElLoading } from 'element-plus'
// 请求
const http = axios.create({
    baseURL: 'http://localhost:10101/',
    timeout: 30000
})
let loadingInstance;
// 请求拦截
http.interceptors.request.use(config => {
    loadingInstance = ElLoading.service({ fullscreen: true })
    //请求头设置
    let token = localStorage.getItem('token') || ''
    config.headers.Authorization = token
    return config
}, err => {
    console.log(err);
})
// 响应拦截
http.interceptors.response.use(arr => {
    loadingInstance.close()
    // 对响应码的处理
    switch (arr.status) {
        case 200:
            if(arr.data&&arr.data.isSuccess){
                return arr.data.data
            }
            // ElMessage({
            //     message: arr.data.message,
            //     type: 'warning',
            // })
            break;
        case 201:
            ElMessage({
                message: arr.statusText,
                type: 'success',
            })
            break;
        case 204:
            ElMessage({
                message: arr.statusText,
                type: 'success',
            })
            break;
        case 400:
            ElMessage({
                message: arr.statusText,
                type: 'warning',
            })
            break;
        case 401:
            ElMessage({
                message: arr.data.message,
                type: 'warning',
            })
            this.$router.push('/login')
            break;
        case 403:
            ElMessage({
                message: arr.statusText,
                type: 'warning',
            })
            break;
        case 404:
            ElMessage({
                message: arr.statusText,
                type: 'warning',
            })
            break;
        case 422:
            ElMessage({
                message: arr.statusText,
                type: 'warning',
            })
            break;
        case 500:
            ElMessage({
                message: arr.statusText,
                type: 'error',
            })
            break;
    }
}, err => {
    loadingInstance.close()
    
    console.log(err)
    switch (err.response.status) {
        case 200:
            if(err.response.data&&err.response.data.isSuccess){
                return err.response.data.data
            }
            // ElMessage({
            //     message: arr.data.message,
            //     type: 'warning',
            // })
            break;
        case 201:
            ElMessage({
                message: err.response.statusText,
                type: 'success',
            })
            break;
        case 204:
            ElMessage({
                message: err.response.statusText,
                type: 'success',
            })
            break;
        case 400:
            ElMessage({
                message: err.response.statusText,
                type: 'warning',
            })
            break;
        case 401:
            ElMessage({
                message: err.response.data.message,
                type: 'warning',
            })
            window.open('/login','_self')
            break;
        case 403:
            ElMessage({
                message: err.response.statusText,
                type: 'warning',
            })
            break;
        case 404:
            ElMessage({
                message: err.response.statusText,
                type: 'warning',
            })
            break;
        case 422:
            ElMessage({
                message: err.response.statusText,
                type: 'warning',
            })
            break;
        case 500:
            ElMessage({
                message: err.response.statusText,
                type: 'error',
            })
            break;
    }
})

export default http