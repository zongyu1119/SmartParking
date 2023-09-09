<template>
  <el-menu default-active="2"
           :router="true"
           class="el-menu-vertical-zyweb"
           :collapse="isCollapse"
           @open="handleOpen"
           @close="handleClose">
    <div class="logo"
         @click="goHome"
         style="background-color: whitesmoke;height: 50px;">
      <el-image src="src\assets\logo.png"
                style="width: 30px;margin-top: 5px;"
                :fit="fit" />
      <span v-show="!isCollapse"
            style="line-height: 50px;height: 50px;">Smart Parking</span>
    </div>

    <el-sub-menu index="1">
      <template #title>
        <el-icon>
          <location />
        </el-icon>
        <span>系统管理</span>
      </template>
      <el-menu-item-group>
        <template #title><span>部门和用户</span></template>
        <el-menu-item index="/dept">部门管理</el-menu-item>
        <el-menu-item index="1-3">用户管理</el-menu-item>
      </el-menu-item-group>
      <el-menu-item-group title="角色和菜单">
        <el-menu-item index="/menu">菜单管理</el-menu-item>
        <el-menu-item index="1-4">角色管理</el-menu-item>
      </el-menu-item-group>
      <el-menu-item index="1-5">参数配置</el-menu-item>
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
</template>

<script>
export default {
  name: 'menu',
  props: {
    isCollapse: {
      typeof: Boolean,
      default: false
    }
  },
  data () {
    return {
      fit: 'contain'
    }
  },
  created () {
  },
  methods: {
    handleOpen (key, keyPath) {
      this.$emit('handleOpen', key, keyPath)
    },
    handleClose (key, keyPath) {
      this.$emit('handleClose', key, keyPath)
    },
    menuCollapse () {
      this.$emit('handleClose')
    },
    goHome () {
      console.log('goHome')
      this.$router.push('/home')
    }

  }
}
</script>

<style>
.logo {
  display: inline-flex;
  align-items: center;
  justify-content: center;
}
.logo:hover {
  cursor: pointer;
}
</style>