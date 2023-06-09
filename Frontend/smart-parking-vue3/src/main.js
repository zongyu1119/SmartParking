import * as Vue from 'vue'
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import App from './App.vue'
import router from './router/router'
import VueCookies from 'vue-cookies'
import axios from 'axios'
import VueAxios from 'vue-axios'
import * as ElementPlusIconsVue from '@element-plus/icons-vue'
//创建并挂载根实例
const app = Vue.createApp(App)
app.config.globalProperties.$cookies = VueCookies;


for (const [key, component] of Object.entries(ElementPlusIconsVue)) {
  app.component(key, component)
}
//确保 _use_ 路由实例使
//整个应用支持路由。
app.use(router)
app.use(ElementPlus)
app.use(VueAxios,axios);
app.mount('#app')
