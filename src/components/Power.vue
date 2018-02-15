<template>
  <div>
    <temp-chart></temp-chart>
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
    ...mapGetters(['sht31', 'bmp280', 'ds18b20']),
  },
};
</script>
