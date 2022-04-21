
<template>
  <div class="common-layout">
    <router-view></router-view>
  </div>
</template>
<script setup>
import { ref } from "vue";
</script>
<script>
export default {
  name: "App",
  data() {
    return {    
      auth:{
        isLogin:false
      }
    };
  },
  mounted() {
  
  },
  methods: {
   
  },
};
</script>
<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  width: 100%;
  height: 100%;
  margin: 0;
  padding: 0;
  background-color: white;
  overflow: hidden;
}
</style>
