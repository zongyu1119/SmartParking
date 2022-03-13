<template>
  <div>
    <div>{{ headerMsg }}</div>
    <button v-on:click="clickCountAdd">点击</button
    ><span>你好，点击了{{ clickCount }}次！</span>
  </div>
</template>
<script>
export default {
  name: 'Hello',
  data () {
    return {
      headerMsg: '点击按钮加1！',
      clickCount: 0
    }
  },
  methods: {
    clickCountAdd () {
      this.clickCount++
    }
  }
}
</script>
