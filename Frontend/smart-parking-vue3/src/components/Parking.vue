<template>
<div>
  <div class="Parking">
    <ParkingSpace v-for="ps in ParkingSpaceList" :key="ps.Id" :ParkingSpaceData="ps" ></ParkingSpace>
  </div>
  <button v-on:click="addParkingSpace">加一个车位</button>
</div>
</template>
<script>
import ParkingSpace from '@/components/ParkingSpace.vue'
export default {
  name: 'Parking',
  components: {
    ParkingSpace
  },
  data () {
    return {
      index: 1,
      ParkingSpaceList: [
        {
          Id: 1,
          /**
           * 占用状态
           * false：空闲
           * true：占用
           */
          occupy: true,
          occupyTime: '2022-03-11 11:36:00',
          freeTime: null,
          CarData: {
            /**
             * 停车记录id
             */
            Id: 1,
            /**
             * 车牌号
             */
            CarNum: '甘A00001',
            /**
             * 进入时间
             */
            InTime: '2022-03-10 17:25:07',
            /**
             * 计费形式
             * 0：临时车
             * 1：月租
             * 2：年租
             * 3：自定义
             */
            BillType: 0,
            /**
             * 当前费用：元
             **/
            CurrCost: 10.1,
            /**
             * 是否在停车库
             * 1：是
             * 0：否
             * 2：其他
             */
            IsInParking: 1,
            /**
             * 出库时间
             */
            OutTime: null,
            /**
             * 停车位置id
             */
            ParkingId: 1
          }
        }
      ]
    }
  },
  methods: {
    addParkingSpace () {
      this.ParkingSpaceList.push({
        Id: ++this.index,
        /**
         * 占用状态
         * false：空闲
         * true：占用
         */
        occupy: true,
        occupyTime: '2022-03-11 11:36:00',
        freeTime: null,
        CarData: {
          /**
           * 停车记录id
           */
          Id: 1,
          /**
           * 车牌号
           */
          CarNum: '甘A00001',
          /**
           * 进入时间
           */
          InTime: '2022-03-10 17:25:07',
          /**
           * 计费形式
           * 0：临时车
           * 1：月租
           * 2：年租
           * 3：自定义
           */
          BillType: 0,
          /**
           * 当前费用：元
           **/
          CurrCost: 10.1,
          /**
           * 是否在停车库
           * 1：是
           * 0：否
           * 2：其他
           */
          IsInParking: 1,
          /**
           * 出库时间
           */
          OutTime: null,
          /**
           * 停车位置id
           */
          ParkingId: 1
        }
      })
    }
  }
}
</script>
<style scoped>
.Parking {
  width: 1000px;
  height: 700px;
  overflow: auto;
  margin: 0;
  padding: 0;
  border: 1px solid #555555;
  border-radius: 10px;
}
</style>
