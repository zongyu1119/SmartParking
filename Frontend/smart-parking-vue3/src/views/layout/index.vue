<template>
  <el-container class="layout-container-zyweb"
                style="height: 100vh;">
    <el-aside style="{boxShadow:var(--el-box-shadow)}">
      <el-scrollbar>
        <Menu @menuCollapse="menuCollapse"
              @handleOpen="handleOpen"
              @handleClose="handleClose"
              :isCollapse="isCollapse" />
      </el-scrollbar>
    </el-aside>
    <el-container>
      <el-header>
        <Header @menuCollapse="menuCollapse"
                :isCollapse="isCollapse" />
      </el-header>
      <el-main style="background-color: white;">
        <el-scrollbar style="width: 100%; height: 100%;"
                      wrap-style="height:100%">
          <router-view style="width: 100%; min-height: 91.5vh;">
          </router-view>
        </el-scrollbar>
      </el-main>
      <el-footer style="font-size: small;font-weight: 300;">
        <Footer />
      </el-footer>
    </el-container>
  </el-container>
</template>
<script >
import { ref } from "vue";
import { getUserInfo } from '@/api/account'
import Footer from '@/components/home/footer.vue';
import Menu from '@/components/home/menu.vue';
import Header from '@/components/home/header.vue';
export default {
  components: { Menu, Footer, Header },
  name: "Layout",
  data () {
    return {
      isCollapse: true,
      auth: {
        isLogin: false
      },
      userInfo: null
    };
  },
  mounted () {
    getUserInfo().then((res) => {
      this.userInfo = res;
      console.log(res)
    });
  },
  methods: {
    handleOpen: (key, keyPath) => {
      console.log(key, keyPath);
    },
    handleClose: (key, keyPath) => {
      console.log(key, keyPath);
    },
    menuCollapse () {
      this.isCollapse = !this.isCollapse
    }
  },
};
</script>
<style scoped >
.layout-container-zyweb .el-header {
  position: relative;
  background-color: var(--el-color-info-light-8);
  color: var(--el-text-color-primary);
  box-shadow: var(--el-box-shadow);
  text-align: right;
  font-size: 12px;
  height: 6vh;
}
.layout-container-zyweb .el-aside {
  color: var(--el-text-color-primary);
  background: var(--el-color-info-light-9);
  width: auto;
  box-shadow: 0 0 10px 10px rgb(250, 248, 248);
}
.layout-container-zyweb .el-menu {
  border-right: none;
  background: var(--el-color-info-light-9);
}
.layout-container-zyweb .el-main {
  padding: 0;
}
.layout-container-zyweb .el-footer {
  box-shadow: var(--el-box-shadow);
  background: var(--el-color-info-light-9);
  height: 2.5vh;
}
.layout-container-zyweb .toolbar {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  height: 100%;
  right: 20px;
}

.layout-container-zyweb.el-menu-vertical-zyweb:not(.el-menu--collapse) {
  width: 200px;
  min-height: 400px;
}
</style>