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
              this.$http.post('/home/Login', { username: this.form.loginname, password: this.form.password })
                  .then(response => {
                      console.log(response);
                      this.$http.post('/home/GetNav')
                      .then(response => {
                          const aa="[{ name: 'fetch-data',path: '/fetch-data', component(resolve) { require(['../components/fetch-data.vue'],resolve) }}]";
                          this.$router.addRoutes(eval(aa));
                          
                          //console.log(response.data.m_StringValue,eval(response.data.m_StringValue));
                      })
                      .catch((error) => console.log(error))
                  })
                  .catch((error) => console.log(error))
          },
          GetNav() {
              this.$http.post('/home/GetNav')
                  .then(response => {
                      console.log(response.data);
                  })
                  .catch((error) => console.log(error))
          }
      }
};</script>