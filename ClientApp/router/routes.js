// 页面路由
export const localRoutes = [
  { name:'login',
    path:'/login',
    component(resolve){
      require(["../components/login.vue"],resolve)
    }
  }
]


 const routeBackup = [
  { name:'login',
    path:'/login',
    component(resolve){
      require(["../components/login.vue"],resolve)
    }
  },
  { name:'app-page',
    path:'/',
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