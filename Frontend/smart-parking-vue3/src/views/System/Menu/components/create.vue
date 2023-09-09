<template>
  <el-dialog v-model="dialogVisibled"
             :title="title"
             width="40vw"
             :before-close="handleClose">
    <slot></slot>
    <el-form :model="data"
             :inline="true">
      <el-form-item label="菜单名称">
        <el-input v-model="data.name" />
      </el-form-item>
      <el-form-item label="菜单编码">
        <el-input :model="data.code"></el-input>
      </el-form-item>
      <el-form-item label="菜单路由">
        <el-input :model="data.code"></el-input>
      </el-form-item>
      <el-form-item label="是否启用">
        <el-input :model="data.code"></el-input>
      </el-form-item>
      <el-form-item label="父菜单">
        <el-input :model="data.code"></el-input>
      </el-form-item>
    </el-form>
    <template #footer>
      <span class="dialog-footer">
        <el-button @click="cancel">取消</el-button>
        <el-button type="primary"
                   @click="confirm">
          提交
        </el-button>
      </span>
    </template>
  </el-dialog>
</template>

<script>
import { ref, watch, toRefs, reactive, computed } from 'vue'
export default {
  props: {
    dialogVisible: {
      tyoeof: Boolean,
      default: false
    },
    title: {
      typeof: String,
      default: "新增菜单"
    }
  },
  setup (props, ctx) {
    //const Store = useStore()
    const dialogVisibled = computed(() => {
      return props.dialogVisible
    })
    const data = reactive({
      content: "测试代码"
    })
    return {
      ...toRefs(data),
      dialogVisibled

    }
  },
  data () {
    return {
      show: false,
      data: {}
    }
  },
  methods: {
    confirm () {
      this.dialogVisibled = false
      this.$emit('confirm')
    },
    cancel () {
      this.dialogVisibled = false
      this.$emit('cancel')
    }, handleClose () {
      this.dialogVisibled = false
      this.$emit('cancel')
    }
  }
}
</script>

<style>
</style>