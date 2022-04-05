<template>
  <div class='car' :style='styleObject' >
    <div class="top">
      <div class="topfree" style="height:3px"></div>
      <div class="topTitle">{{ CarData.CarNum }}</div>
    </div>
  </div>
</template>
<script>
export default {
  name: 'Car',
  props: [
    'CarData'
  ],
  data () {
    return {
      styleObject: {
      }
    }
  }
}
</script>
<!--添加“scoped”属性，将CSS限制为仅用于此组件-->
<style scoped>
.car {
  background-color: rgba(240, 240, 240, 0.8);
  border: 0.5px solid rgba(200, 200, 200, 0.5);
  float: left;
  border-radius: 10px;
  box-sizing: border-box;
  box-shadow: 2px 2px 1px #888888;
  overflow: hidden;
  width: 120px;
  height: 100px;
}
.car:hover {
  background-color: #bbbbbb;
}
.top{
  margin: 0;
  text-align: center;
  height: 20px;
  width: 70px;
  overflow: hidden;
  background-color: #3498DB;
  font-weight: 600;
  font-size: 12px;
  float: left;
  color: #FFFFFF;
  padding: 0;
}
.topFree{
  float: left;
  width: 100%;
  margin: 0;
  padding: 0;
  height: 5px;
}
.topTitle{
  width: 100%;
  margin: 0;
  padding: 0;
  height: 15px;
  float: left;
  text-align: center;
}
</style>
