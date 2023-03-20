<template>
  <el-container class="layout-container-zyweb"
                style="height: 100vh;">
    <el-aside style="{boxShadow:var(--el-box-shadow)}">
      <el-scrollbar>
        <el-menu default-active="2"
                 class="el-menu-vertical-zyweb"
                 :collapse="isCollapse"
                 @open="handleOpen"
                 @close="handleClose">
          <div class="logo"
               style="background-color: whitesmoke;">
            <el-image src="src\assets\logo.png"
                      style="width: 40px;margin-top: 5px;"
                      :fit="fit" />
            <el-text v-show="!isCollapse">Smart Parking</el-text>
          </div>

          <el-sub-menu index="1">
            <template #title>
              <el-icon>
                <location />
              </el-icon>
              <span>Navigator One</span>
            </template>
            <el-menu-item-group>
              <template #title><span>Group One</span></template>
              <el-menu-item index="1-1">item one</el-menu-item>
              <el-menu-item index="1-2">item two</el-menu-item>
            </el-menu-item-group>
            <el-menu-item-group title="Group Two">
              <el-menu-item index="1-3">item three</el-menu-item>
            </el-menu-item-group>
            <el-sub-menu index="1-4">
              <template #title><span>item four</span></template>
              <el-menu-item index="1-4-1">item one</el-menu-item>
            </el-sub-menu>
          </el-sub-menu>
          <el-menu-item index="2">
            <el-icon><icon-menu /></el-icon>
            <template #title>Navigator Two</template>
          </el-menu-item>
          <el-menu-item index="3"
                        disabled>
            <el-icon>
              <document />
            </el-icon>
            <template #title>Navigator Three</template>
          </el-menu-item>
          <el-menu-item index="4">
            <el-icon>
              <setting />
            </el-icon>
            <template #title>Navigator Four</template>
          </el-menu-item>
        </el-menu>
      </el-scrollbar>
    </el-aside>

    <el-container>
      <el-header>
        <el-row :gutter="2"
                style="height: 100%;">
          <el-col :span="1"
                  style="height: 100%;text-align: left;">
            <div @click="menuCollapse()"
                 class="toolbar">
              <el-icon size="20px">
                <Fold v-if="!isCollapse" />
                <Expand v-else />
              </el-icon>
            </div>
          </el-col>
          <el-col :span="20"></el-col>
          <el-col :span="3"
                  class="toolbar">
            <el-dropdown>
              <el-icon style="margin-right: 8px; margin-top: 1px">
                <setting />
              </el-icon>
              <template #dropdown>
                <el-dropdown-menu>
                  <el-dropdown-item>个人信息</el-dropdown-item>
                  <el-dropdown-item>修改密码</el-dropdown-item>
                  <el-dropdown-item>退出登录</el-dropdown-item>
                </el-dropdown-menu>
              </template>
            </el-dropdown>
            <span>{{userInfo?userInfo.userName:''}}</span>
          </el-col>
        </el-row>
      </el-header>

      <el-main>
        <el-scrollbar>
          main
        </el-scrollbar>
      </el-main>
      <el-footer>
        footer
      </el-footer>
    </el-container>
  </el-container>
</template>

<script>
import { ref } from 'vue'
import { getUserInfo } from '@/api/account'
export default {
  name: "Home",
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

}
</script>

<style scoped>
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
.logo {
  display: inline-flex;
  align-items: center;
  justify-content: center;
}
.layout-container-zyweb.el-menu-vertical-zyweb:not(.el-menu--collapse) {
  width: 200px;
  min-height: 400px;
}
</style>