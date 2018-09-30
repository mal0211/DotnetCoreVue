import Vue from 'vue'
import VueRouter from 'vue-router'
import { localRoutes } from './routes'

Vue.use(VueRouter)

let router = new VueRouter({
  mode: 'hash',
  routes:localRoutes 
})

export default router


