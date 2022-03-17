<template>
  <div class="ParkingSpace" :class="[ParkingSpaceData.occupy ? 'ParkingSpaceOccupy' : '']">
    <Car :CarData='ParkingSpaceData.CarData'></Car>
  </div>
</template>
<script>
import Car from '@/components/Car.vue'
export default {
  name: 'ParkingSpace',
  components: {
    Car
  },
  props: ['ParkingSpaceData'],
  data () {
    return {
    }
  }
}
</script>
<style scoped>
.ParkingSpaceOccupy {
  background-color: #fde091;
}
.ParkingSpace {
  width: 80px;
  height: 60px;
  border: 1px solid #aaaaaa;
  float: left;
  border-radius: 10px;
  box-sizing: border-box;
  box-shadow: 5px 5px 3px #888888;
  overflow: hidden;
}
</style>
