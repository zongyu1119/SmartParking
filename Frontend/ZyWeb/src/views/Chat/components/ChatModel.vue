<template>
  <el-container class="content" v-show="currGroup && currGroup.id">
    <el-header class="header" style=""
      ><el-icon class="icon" color="white" size="30px"><UserFilled /></el-icon>
      <div class="name">
        {{ currGroup ? (currGroup.isGroup ? currGroup.name : currGroup.firend.name) : '' }}
      </div>
    </el-header>
    <el-main style="padding: 0">
      <div class="msg" ref="msgScroll">
        <Msg v-for="(msg, index) in receiveMsgList" v-bind:key="index" :msg="msg"></Msg></div
    ></el-main>
    <el-footer height="200px" style="padding: 0"
      ><div class="form">
        <el-form>
          <el-input
            v-model="msg"
            type="textarea"
            placeholder="Please input message content."
            class="formText"
            resize="none"
            rows="4"
            clearable
            @keyup.enter="sendMsg"
          /><el-button round size="large" class="resetBtn" @click="resetMsg">Clear</el-button
          ><el-button class="sendBtn" @click="sendMsg" round size="large">Send</el-button>
        </el-form>
      </div></el-footer
    >
  </el-container>
</template>

<script>
import * as signalR from '@microsoft/signalr'
import Msg from './Msg.vue'
import { onMounted, ref } from 'vue'
import { toRaw } from '@vue/reactivity'
import { getUserInfo } from '@/untils'
import { getNewMessage } from '@/api/message.js'
import { envBaseUrl } from '@/api/http.js'
import { encrypt, decrypt } from '@/untils/Des.js'
export default {
  components: { Msg },
  props: { group: Object },
  data() {
    return {
      connection: null,
      receiveMsgList: [],
      msg: '123',
      user: {},
      currGroup: null //当前聊天的组
    }
  },
  setup(props) {
    let msgScroll = ref(null)
    onMounted(async () => {})
    return {
      msgScroll,
      props
    }
  },
  watch: {
    group(after, before) {
      if (after && after != before) {
        this.currGroup = toRaw(after)
        this.receiveMsgList = []
        this.getMessageList(after.id)
      }
    }
  },
  async mounted() {
    const token = localStorage.getItem('token')
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(envBaseUrl + '/chathub', {
        accessTokenFactory: () => token,
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .configureLogging(signalR.LogLevel.Information)
      .withAutomaticReconnect()
      .build()
    await this.connect()
    this.user = getUserInfo()
  },
  methods: {
    async start() {
      try {
        await this.connection.start()
        console.log('SignalR Connected.')
      } catch (err) {
        console.log(err)
        setTimeout(this.start, 5000)
      }
    },
    async connect() {
      let that = this
      this.connection.onclose(async () => {
        await this.start()
      })
      this.connection.on('ReceiveMessage', function (res) {
        if (that.currGroup && res.receiveId === that.currGroup.id) {
          var sendUser = that.currGroup.users.find((x) => res.sendUserId === x.id)
          const msgStr = decrypt(res.message)
          that.receiveMsgList.push({
            message: msgStr,
            user: sendUser,
            time: res.time,
            isMe: res.sendUserId === that.user.userId
          })
        }
        if (that.msgScroll != null) {
          setTimeout(() => {
            that.msgScroll.scrollTop = that.msgScroll.scrollHeight
          }, 25)
        }
      })
      // Start the connection.
      await this.start()
    },
    sendMsg() {
      try {
        if (this.msg) {
          this.msg = this.msg.replace(/^\s+|\s+$/g, '')
          const msgStr = encrypt(this.msg)
          const msg = { message: msgStr, ReceiveId: this.currGroup.id }
          this.connection.invoke('SendMessage', msg).then(() => {
            this.msg = ''
          })
        }
      } catch (err) {
        console.error(err)
      }
    },
    resetMsg() {
      this.msg = ''
    },
    getMessageList(groupId, time) {
      let that = this
      getNewMessage({
        GroupId: groupId,
        Time: time
      }).then((res) => {
        if (res) {
          res.forEach((element) => {
            var sendUser = that.currGroup.users.find((x) => element.sendUserId === x.id)
            const msgStr = decrypt(element.message)
            that.receiveMsgList.unshift({
              message: msgStr,
              user: sendUser,
              time: element.time,
              isMe: element.sendUserId === that.user.userId
            })
          })
          if (that.msgScroll != null) {
            setTimeout(() => {
              that.msgScroll.scrollTop = that.msgScroll.scrollHeight
            }, 25)
          }
        }
      })
    }
  }
}
</script>

<style scoped lang="scss">
.content {
  margin: 0;
  width: 100%;
  height: 100%;
  padding: 0;
  .header {
    background-color: #3598db;
    height: 40px;
    line-height: 40px;
    padding: 0 10px;
    .icon {
      margin-top: 5px;
      float: left;
    }
    .name {
      font-size: 25px;
      line-height: 40px;
      margin: 0 10px;
      color: white;
      padding: 0;
      max-width: max-content;
      float: left;
    }
  }
  .form {
    width: 100%;
    background-color: #f2f2f2;
    padding: 0px;
    height: 200px;
    overflow: hidden;
    float: left;
    .formText {
      font-size: 20px;
      line-height: 22px;
      border-top: 2px solid #7ebde8;
      border-bottom: 2px solid #7ebde8;
      border-left: none;
      border-right: none;
    }
    .resetBtn {
      font-weight: 600;
      float: left;
      margin-left: 15px;
      margin-top: 15px;
      width: 120px;
    }
    .sendBtn {
      background-color: #3598db;
      color: white;
      font-weight: 600;
      float: right;
      margin-right: 15px;
      margin-top: 15px;
      width: 120px;
    }
  }
  .msg {
    width: 100%;
    height: 100%;
    overflow: auto;
    margin: 0;
    padding: 15px;
  }
}
</style>