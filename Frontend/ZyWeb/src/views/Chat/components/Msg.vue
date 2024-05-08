<template>
  <div class="msgBox">
    <div :class="[msg.isMe ? 'msgContentMe' : 'msgContent']">
      <div class="avatar">{{ msg.user.name.substring(0, 1) }}</div>
      <div class="content">
        <div class="time">{{ msg.time }}</div>
        <div class="message">
          {{ msg.message }}
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ['msg'],
  setup(props) {
    //console.log(props)
    //this.message = props.msg.message
  }
}
</script>

<style lang="scss" scoped>
.msgBox {
  width: 100%;
  float: left;

  .msgContentMe {
    max-width: 4600px;
    min-width: 50px;
    margin: 10px 5px;
    float: right;
    .avatar {
      width: 50px;
      height: 50px;
      border-radius: 50%;
      text-align: center;
      line-height: 50px;
      font-size: 20px;
      padding: 0;
      margin-top: 10px;
      box-shadow: 5px 3px 3px #f0f0f0;
      background-color: #f0f0f0;
      float: right;
      color:#3598db;
    }
    .content {
      min-height: 40px;
      float: left;
      max-width: 400px;
      margin-right: 5px;
      .time {
        font-size: 12px;
        text-align: right;
      }
      .message {
        word-break: break-all;
        min-height: 40px;
        line-height: 20px;
        border-radius: 10px;
        box-shadow: 5px 3px 3px #f0f0f0;
        padding: 10px 8px;
        font-size: 16px;
        background-color: #3598db;
        color: white;
      }
    }
  }
  .msgContent {
    max-width: 460px;
    min-width: 50px;
    margin: 10px 5px;
    float: left;
    .avatar {
      width: 50px;
      height: 50px;
      margin-top: 10px;
      border-radius: 50%;
      text-align: center;
      line-height: 50px;
      font-size: 20px;
      padding: 0;
      box-shadow: 5px 3px 3px #f0f0f0;
      background-color: #3598db;
      float: left;
      color: white;
    }
    .content {
      min-height: 40px;
      float: left;
      margin-right: 5px;
      max-width: 400px;
      .time {
        font-size: 12px;
      }
      .message {
        min-height: 40px;
        word-break: break-all;
        line-height: 40px;
        border-radius: 10px;
        box-shadow: 5px 3px 3px #f0f0f0;
        padding: 0 8px;
        font-size: 18px;
        background-color: #f0f0f0;
        float: left;
        margin-left: 5px;
        color: #000000;
      }
    }
  }
}
</style>