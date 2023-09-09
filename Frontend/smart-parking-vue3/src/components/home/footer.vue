<template>
  {{ author }} 2022-{{ new Date().getFullYear() }}
</template>

<script>
export default {
  name: 'footer',
  data () {
    return {
      author: 'zongyu'
    }
  }
}
</script>

<style>
</style>