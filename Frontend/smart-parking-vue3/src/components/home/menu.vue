<template>
  <el-menu default-active="2"
           :router="true"
           class="el-menu-vertical-zyweb"
           :collapse="isCollapse"
           @open="handleOpen"
           @close="handleClose">
    <div class="logo"
         style="background-color: whitesmoke;height: 30px;">
      <el-image src="src\assets\logo.png"
                style="width: 30px;margin-top: 5px;"
                :fit="fit" />
      <span v-show="!isCollapse"
            style="line-height: 30px;height: 30px;">Smart Parking</span>
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
        <el-menu-item index="/dept">部门管理</el-menu-item>
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
    }

  }
}
</script>

<style>
</style>