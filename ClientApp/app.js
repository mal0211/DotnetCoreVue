import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';


// Registration of global components
Vue.component('icon', FontAwesomeIcon)

Vue.prototype.$http = axios

Vue.use(ElementUI);

sync(store, router)

/*想用来解决刷新丢失route数据问题,但是没有成功*/ 
var getLastUrl=(str,yourStr)=>str.slice(str.lastIndexOf(yourStr))//取到浏览器出现网址的最后"/"出现的后边的字符

router.beforeEach((to, from, next) => {
  if(store.state.menuList!=false)
  {
    console.log(111)
    if(getLastUrl(window.location.href,'/')==to.path)
    {
      console.log(333)
      router.addRoutes(this.$store.state.menuList)
    }
  }
  else{
    console.log(222)
  }
  
  next()
})


const app = new Vue({
  el:"#app",
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}