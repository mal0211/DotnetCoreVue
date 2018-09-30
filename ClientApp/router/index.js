import Vue from 'vue'
import VueRouter from 'vue-router'
import { localRoutes } from './routes'

Vue.use(VueRouter)

let router = new VueRouter({
  mode: 'history',
  routes:localRoutes 
})

router.beforeEach((to, from, next) => {
  console.log(to);  
  
  console.log(localRoutes)
  next()

})
export default router


