<template>
  <el-form style="padding-top: 3px;">
    <el-row :gutter="24">
      <el-col :span="6"
              :offset="18">
        <el-form-item style="float: right;margin-right: 3px;">
          <el-button type="primary"
                     @click="createCilck">查询</el-button>
          <el-button type="default"
                     @click="createCilck">重置</el-button>
          <el-button type="primary"
                     @click="createCilck">新增菜单</el-button>
        </el-form-item>
      </el-col>
    </el-row>

  </el-form>
  <el-table :data="dataList"
            style="width: 100%">
    <template v-for="item in colums"
              :key="item.id">
      <el-table-column :fixed="item.fixed"
                       :prop="item.prop"
                       :label="item.label"
                       :width="item.width" />
    </template>
    <el-table-column fixed="right"
                     label="操作"
                     width="160">
      <template #default="scope">
        <el-button link
                   type="primary"
                   size="small"
                   @click="handleClick(scope.row)">详情</el-button>
        <el-button link
                   type="primary"
                   size="small">编辑</el-button>
        <el-button size="small"
                   type="danger"
                   @click="handleDelete(scope.$index, scope.row)">删除</el-button>
      </template>
    </el-table-column>
  </el-table>
  <createDialog :dialogVisible="createDialogVisible"
                @cancel="handleCreateCancel"
                @confirm="handleCreateCancel">

  </createDialog>
</template>
<script>
import { create, get } from '@/api/menu'
import createDialog from './components/create.vue'
export default {
  components: { createDialog },
  name: 'Menu',
  data () {
    return {
      dataList: [],
      queryData: {},
      createDialogVisible: false,
      colums: [{
        fixed: false,
        prop: 'name',
        label: '菜单名称'
      }, {
        fixed: false,
        prop: 'code',
        label: '菜单编码'
      }]
    }
  }, mounted () {
    this.getDataList()
  },
  methods: {
    getDataList () {
      get({}).then((data) => {
        console.log(data)
      })
    },
    create () {

    },
    createCilck () {
      this.createDialogVisible = true
    },
    handleCreateCancel () {
      this.createDialogVisible = false
    }
  }
}
</script>