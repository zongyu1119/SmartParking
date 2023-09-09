
<template>
  <router-view>
  </router-view>
</template>
<script setup>
import { ref } from "vue";
import Layout from '@/views/layout/index.vue'
</script>
<script>
export default {
  components: { Layout },
  name: "App",
  data () {
    return {

    };
  },
  mounted () {

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

