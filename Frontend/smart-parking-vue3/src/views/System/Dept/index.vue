<template>
  <el-table :data="dataList"
            style="width: 100%">
    <el-table-column fixed
                     prop="date"
                     label="Date"
                     width="180" />
    <el-table-column prop="name"
                     label="Name"
                     width="180" />
    <el-table-column prop="address"
                     label="Address" />
    <el-table-column fixed="right"
                     label="Operations"
                     width="160">
      <template #default>
        <el-button link
                   type="primary"
                   size="small"
                   @click="handleClick">详情</el-button>
        <el-button link
                   type="primary"
                   size="small">编辑</el-button>
      </template>
    </el-table-column>
  </el-table>
</template>
<script>
export default {
  data () {
    return {
      dataList: []
    }
  }, mounted () {
    this.dataList = [{
      date: '2016-05-03',
      name: 'Tom',
      address: 'No. 189, Grove St, Los Angeles',
    },
    {
      date: '2016-05-02',
      name: 'Tom',
      address: 'No. 189, Grove St, Los Angeles',
    },
    {
      date: '2016-05-04',
      name: 'Tom',
      address: 'No. 189, Grove St, Los Angeles',
    },
    {
      date: '2016-05-01',
      name: 'Tom',
      address: 'No. 189, Grove St, Los Angeles',
    },]
  },
  methods: {

  }
}
</script>