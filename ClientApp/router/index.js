import Vue from 'vue'
import VueRouter from 'vue-router'
import { routes } from './routes'

Vue.use(VueRouter)

const routeBackup = [
  { name:'login',
    path:'/login',
    component(resolve){
      require(["../components/login.vue"],resolve)
    }
  },
  { name:'app-page',
    path:'/',
    redirect:'/home',
    component(resolve){
      require(["../components/app-page.vue"],resolve)
    },
    children:[
      { name: 'home', 
        path: '/home', 
        component(resolve){
          require(["../components/home-page.vue"],resolve)
        }, 
        display: 'Home', 
        icon: 'home' 
      },
      { name: 'counter', 
        path: '/counter', 
        component(resolve){
          require(["../components/counter-example.vue"],resolve)
        }, 
        display: 'Counter', 
        icon: 'graduation-cap' 
      },
      { name: 'fetch-data', 
        path: '/fetch-data', 
        component(resolve){
          require(["../components/fetch-data.vue"],resolve)
        }, 
        display: 'Fetch data', 
        icon: 'list' 
      }
    ]
  }
]

let router = new VueRouter({
  mode: 'history',
  routes
})
const aa="[{ name: 'fetch-data', path: '/fetch-data', component(resolve){  require(['../components/fetch-data.vue'],resolve)}, display: 'Fetch data', icon: 'list'}]";
const bb="function aa(){ console.log('eval success111') } "
eval(bb)
router.addRoutes(eval(aa));
//router.addRoutes(routeConfig)

export default router