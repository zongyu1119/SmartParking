import * as VueRouter from 'vue-router';
import Hello from '@/components/Hello.vue'
import HelloWorld from '@/components/HelloWorld.vue'
import Parking from '@/components/Parking.vue'

const routes=[
    {path:'/Hello',name:Hello,component:Hello},
    {path:"/HelloWorld",name:HelloWorld,component:HelloWorld},
    {path:'',redirect:"Hello"},
    {path:'/Parking',name:Parking,component:Parking}
]

const router=new VueRouter.createRouter({
    history: VueRouter.createWebHistory(),
    routes: routes
  });

export default router
