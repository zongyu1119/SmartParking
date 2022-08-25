<template>
     <el-container class="content">
      <el-header id="header" height="40px">
        <el-radio-group v-model="isCollapse" style="margin-bottom: 20px;float:left;margin-left:1px">
          <el-radio-button :label="false">展开</el-radio-button>
          <el-radio-button :label="true">折叠</el-radio-button>
        </el-radio-group>
         <el-button type="info" round>Info</el-button>
      </el-header>
      <el-container :style="{ height: bodyHeight - 60 + 'px' }">
     
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
import {GetUserDetailInfoToView} from "@/assets/Scripts/api"
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
    GetUserDetailInfoToView().then((Res)=>{
        console.log(Res)
    });
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
  margin:0;
  padding:0;
}
#header {
  background-color: #ebeef5;
  width: 100%;
  margin:0;
  padding:0;
}
#aside {
  background-color: whitesmoke;
  margin:0;
  padding:0;
}
#main {
  background-color: #FFFFFF;
  margin:0;
  padding:0;
}
.content{
  margin:0;
  padding:0;
}
</style>