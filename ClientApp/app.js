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