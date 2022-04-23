<template>
     <el-container>
      <el-header id="header" height="40px">
        <el-radio-group v-model="isCollapse" style="margin-bottom: 20px;float:left">
          <el-radio-button :label="false">expand</el-radio-button>
          <el-radio-button :label="true">collapse</el-radio-button>
        </el-radio-group>
      </el-header>
      <el-container :style="{ height: bodyHeight - 60 + 'px' }">
        <el-aside
          id="aside"
          :style="{ height: bodyHeight - 40 + 'px',maxWidth:200+'px' }"
        >
          <el-menu
            default-active="2"
            :collapse="isCollapse"
            @open="handleOpen"
            @close="handleClose"  
            :router="true"
          >
            <el-sub-menu index="1">
              <template #title>
                <el-icon><location /></el-icon>
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
            <el-menu-item index="3" disabled>
              <el-icon><document /></el-icon>
              <template #title>Navigator Three</template>
            </el-menu-item>
            <el-menu-item index="4">
              <el-icon><setting /></el-icon>
              <template #title>Navigator Four</template>
            </el-menu-item>
          </el-menu>
        </el-aside>
        <el-container id="container">
          <el-main
            id="main"
            :style="{ height: bodyHeight - 60 + 'px', width: '100%' }">
            <el-scrollbar :height="bodyHeight - 60 + 'px'">
              <router-view :style="{boxShadow:`var(${'--el-box-shadow-dark'})`,backgroundColor:'#FFFFFF'}"></router-view>
            </el-scrollbar>
          </el-main>
          <el-footer height="20px" id="footer"> Footer </el-footer>
        </el-container>
      </el-container>
    </el-container>
</template>

<script setup>
import {
  Document,
  Menu as IconMenu,
  Location,
  Setting,
} from "@element-plus/icons-vue";
import { ref } from "vue";
</script>
<script>
export default {
name: "Home",
  data() {
    return {
      bodyHeight: window.innerHeight,
      bodyWidth: window.innerWidth,
      isCollapse: ref(true),
      auth:{
        isLogin:false
      }
    };
  },
  mounted() {
    const that = this;
    window.onresize = () => {
      return (() => {
        that.bodyHeight = window.innerHeight;
        that.bodyWidth = window.innerWidth;
      })();
    };
  },
  methods: {
    handleOpen: (key, keyPath) => {
      console.log(key, keyPath);
    },
    handleClose: (key, keyPath) => {
      console.log(key, keyPath);
    },
  },
}
</script>

<style scoped>
#footer {
  background-color: rgba(230, 230, 230, 0.482);
  font-size: large;
  position: fixed;
  bottom: 0;
  width: 100%;
}
#header {
  background-color: #ebeef5;
  width: 100%;
}
#aside {
  background-color: whitesmoke;
}
#main {
  background-color: #FFFFFF;
}
</style>