<template>
  <el-row :gutter="2"
          style="height: 100%;">
    <el-col :span="1"
            style="height: 100%;text-align: left;">
      <div @click="menuCollapse()"
           class="toolbar">
        <el-icon size="20px"
                 style="margin-top: 10px;">
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
</template>

<script>
export default {
  name: 'header',
  props: {
    isCollapse: {
      typeof: Boolean,
      default: false
    }
  },
  data () {
    return {
      userInfo: {}
    }
  },
  created () {
    console.log('Header')
  },
  methods: {
    menuCollapse () {
      this.$emit('menuCollapse')
    }
  }
}
</script>

<style>
</style>
