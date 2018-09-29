export const routes = [
  { name:'login',
    path:'/login',
    component(resolve){
      require(["../components/login.vue"],resolve)
    }
  }
]