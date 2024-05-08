<script setup>
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
import Chat from '@/views/Chat/Chat.vue'
</script>

<template>
  <div class="body">
    <el-container style="height: 100%">
      <el-container style="height: 100vh">
        <el-aside width="50px" class="menu" style="background-color: #3598db; height: 100%">
          <RouterLink to="/"
            ><el-icon class="router" size="35px" color="white"><ChatLineRound /></el-icon
          ></RouterLink>
          <RouterLink to="/userList"
            ><el-icon class="router" size="35px" color="white"><User /></el-icon></RouterLink
        ></el-aside>
        <RouterView />
      </el-container>
    </el-container>
  </div>
</template>

<style scoped lang="scss">
.body {
  width: 100vw;
  height: 100vh;
  margin: 0;
  padding: 0;
  overflow: hidden;
  .menu {
    padding-top: 15px;
    .router {
      margin: 15px 7.5px;
    }
  }
}
</style>
