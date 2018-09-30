<template>
  <div>
    <el-container>
      <el-main>
        <el-form ref="form" :model="form" label-width="80px">
          <el-form-item label="用户名">
            <el-input v-model="form.loginname" placeholder="请输入用户名"></el-input>
          </el-form-item>
          <el-form-item label="密码">
            <el-input v-model="form.password" placeholder="请输入密码"></el-input>
          </el-form-item>

          <el-form-item>
            <el-button type="primary" @click="onSubmit">立即创建</el-button>
            <el-button>取消</el-button>
          </el-form-item>

        </el-form>

        <el-button></el-button>
      </el-main>
    </el-container>
  </div>
</template>
<script>

export default {
    
      data() {
          return {
              form: {
                  loginname: '',
                  password: ''
              }
          }
      },
      methods: {
          onSubmit() {
              var _self=this;
              _self.$http.post('/home/Login', { username: this.form.loginname, password: this.form.password })
                  .then(response => {
                      _self.$http.post('/home/GetNav')
                      .then(response => {
                        var addRouteConfig=[];
                         addRouteConfig=convertRouteMap(response.data);                        
                        _self.$router.addRoutes(addRouteConfig);
                        console.log(addRouteConfig);
                      })
                      .catch((error) => console.log(error))
                  })
                  .catch((error) => console.log(error))
          }
      }
};
/**
 * 后台返回的node数据转换为route
 * @param menus
 * @returns {Array}
 */
function convertRouteMap(nodes) {
  let routers = [];
  if (nodes) {
      for (let node of nodes) {          
          const componentVal = resolve => {
             require([''+node.com], resolve)
          };
           console.log(node.com);
          let route = {path: node.path,name: node.name, component: componentVal};
          if (node.children) {
              route.children = convertRouteMap(node.children);
          }
          if (node.redirect) {
              route.redirect = node.redirect;
          }
          routers.push(route);
      }
  }
  
  return routers; 
}
</script>