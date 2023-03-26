import * as VueRouter from 'vue-router';
import Hello from '@/components/Hello.vue'
import HelloWorld from '@/components/HelloWorld.vue'
import Parking from '@/components/Parking.vue'

const routes = [  
  {
    path: "/Home",
    name: "Home",
    component: ()=>import('@/views/Home/index.vue'),
    children:[
      { path: "/Hello", name: Hello, component: Hello },
      { path: "/HelloWorld", name: HelloWorld, component: HelloWorld },
      { path: "/Parking", name: Parking, component: Parking },
    ]
  }, 
  {
    path: "/login",
    name: "Login",
    component: ()=>import('@/views/Login/index.vue'),
  },
  {
    path:"/dept",
    name:"dept",
    component:()=>import('@/views/System/Dept/index.vue')
  }
];

const router=new VueRouter.createRouter({
    history: VueRouter.createWebHistory(),
    routes: routes
  });
// 使用 router.beforeEach 注册一个全局前置守卫，判断用户是否登陆
router.beforeEach((to, from, next) => { // 三个参数分别是要去哪里， 从哪里来，接下来应该怎么做
	if(to.path === "/login"){
		next();
	} else if(to.path==='/'){
    next('/Home');
  }else{
    // 用户只要访问除了登陆页面的其他页面，程序都要检查用户的令牌获取情况，如果没有令牌，直接前往登陆页面，如果有令牌就放行
		console.log("路由守卫执行,to:"+to.path);
    let token = localStorage.getItem('token')
		if(token === "" || token === null||token === 'undefined'||token === undefined){
			next("/login")
		}else{
			next()
		}
	}
});
export default router
