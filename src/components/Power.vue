<template>
  <div>
    <temp-chart :data=this.dataValues :labels=this.dataLabels></temp-chart>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';
import TemperatureChart from './charts/TemperatureChart';

export default {
  components: {
    'temp-chart': TemperatureChart,
  },
  computed: {
    ...mapGetters(['sht31', 'bmp280', 'ds18b20', 'sht31oneDay']),
    dataValues() {
      return this.sht31oneDay.map(a => a.fahrenheit);
    },
    dataLabels() {
      return this.sht31oneDay.map(a => a.time);
    },
  },
};
</script>
