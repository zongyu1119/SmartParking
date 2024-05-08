<template>
  <el-container class="body">
    <el-aside class="chatListUser" width="180px">
      <div class="user">
        <div class="avatar">{{ avatar }}</div>
        <div class="name">{{ user.name }}</div>
      </div>
      <div class="chatList" style="">
        <div
          :class="['group', group.id === currGroup.id ? 'currgoup' : '']"
          v-for="group in groupList"
          :key="group.id"
          @click="chatForm(group)"
        >
          <div class="avatar">
            <el-badge
              is-dot
              :type="group.firend.isOnline ? 'success' : 'warning'"
              class="dot"
              v-if="!group.isGroup"
            >
              {{ group.firend.name.substring(0, 1) }}
            </el-badge>
            <span v-else class="dot"> {{ group.name.substring(0, 1) }}</span>
          </div>
          <div class="name">{{ group.isGroup ? group.name : group.firend.name }}</div>
        </div>
      </div>
    </el-aside>
    <ChatModelVue class="content" :group="currGroup"></ChatModelVue>
  </el-container>
</template>
<script>
import { RsaKey, Encode, Decode } from '@/untils/Rsa.js'
import { getUserInfo } from '@/untils'
import { dayjs } from 'element-plus'
import { onMounted, ref } from 'vue'
import { getChatGroup } from '@/api/user.js'
import ChatModelVue from './components/ChatModel.vue'
export default {
  components: { ChatModelVue },
  data() {
    return {
      test: dayjs().format(),
      user: {},
      avatar: 'A',
      groupList: [],
      currGroup: {}
    }
  },
  mounted() {
    this.user = getUserInfo()
    console.log(this.user)
    if (this.user && this.user.name) this.avatar = this.user.name.substring(0, 1)
    this.getChatGroupList()
  },
  methods: {
    getChatGroupList() {
      getChatGroup().then((res) => {
        if (res) {
          res.forEach((element) => {
            if (!element.isGroup) {
              element.firend = element.users.find((x) => x.id != this.user.userId)
            }
          })
        }
        this.groupList = res
      })
      setInterval(() => {
        getChatGroup().then((res) => {
          if (res) {
            res.forEach((element) => {
              if (!element.isGroup) {
                element.firend = element.users.find((x) => x.id != this.user.userId)
              }
            })
          }
          this.groupList = res
        })
      }, 1000 * 60)
    },
    chatForm(group) {
      this.currGroup = group
    }
  }
}
</script>

<style scoped lang="scss">
.body {
  width: 100%;
  height: 100vh;
  margin: 0;
  padding: 0;
  .chatListUser {
    background-color: #7ebde8;
    height: 100%;
    overflow: hidden;
    .user {
      background-color: #3598db;
      height: 40px;
      width: 100%;
      cursor: pointer;
      .avatar {
        width: 30px;
        height: 30px;
        border-radius: 50%;
        text-align: center;
        line-height: 30px;
        font-size: 20px;
        padding: 0;
        margin-top: 5px;
        margin-left: 5px;
        background-color: #f0f0f0;
        float: left;
        font-weight: 600;
      }
      .name {
        font-size: 25px;
        margin: 0 5px;
        padding: 0;
        float: left;
        line-height: 30px;
        color: white;
      }
    }
    .chatList {
      height: calc(100vh - 40px);
      width: 200px;
      overflow-y: auto;
      .currgoup {
        background-color: #3598db;
      }
      .group {
        height: 40px;
        width: 100%;
        border-top: 0.1px solid white;
        border-bottom: 0.1px solid white;
        cursor: pointer;
        .avatar {
          width: 30px;
          height: 30px;
          border-radius: 50%;
          text-align: center;
          line-height: 30px;
          font-size: 20px;
          padding: 0;
          margin-top: 5px;
          margin-left: 5px;
          background-color: #f0f0f0;
          float: left;
          font-weight: 600;
          .dot {
            float: left;
            margin: 0;
            padding: 0;
            width: 30px;
            height: 30px;
          }
        }
        .name {
          font-size: 25px;
          margin: 0 5px;
          padding: 0;
          float: left;
          line-height: 30px;
          color: white;
        }
      }
    }
  }
  .content {
    margin: 0;
    width: 50%;
    height: 100%;
    padding: 0;    
    background-color: #FFFFFF;
  }
}
</style>