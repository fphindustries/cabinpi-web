<template>
  <div class="wrapper content flexcv">
    <div class="row flexh">
      <div class="column">
        <h3 class="text-green-3">BATTERY V</h3>
      </div>
      <div class="column">
        <h1 class="text-green-2">{{ solar.dispavgVbatt | formatNumber }}</h1>
      </div>
      <div class="column">
        <h3 class="text-green-3">PV V</h3>
      </div>
      <div class="column">
        <h1 class="text-green-2">{{ solar.dispavgVpv | formatNumber }}</h1>
      </div>
    </div>
    <div class="row flexh">
      <div class="column">
        <h3 class="text-green-3">BATTERY I</h3>
      </div>
      <div class="column">
        <h3 class="text-green-2">{{ solar.IbattDisplay | formatNumber }}</h3>
      </div>
      <div class="column">
        <h3 class="text-green-3">kWH IN</h3>
      </div>
      <div class="column">
        <h3 class="text-green-2">{{ solar.kWHours | formatNumber }}</h3>
      </div>
      <div class="column">
        <h3 class="text-green-3">WATTS</h3>
      </div>
      <div class="column">
        <h3 class="text-green-2">{{ solar.watts }}</h3>
      </div>
    </div>
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
    ...mapGetters(['solar', 'solar24Hours']),
    dataValues() {
      return this.solar24Hours.map(a => a.ext_f);
    },
    dataLabels() {
      return this.solar24Hours.map(a => a.time);
    },
  },
};
</script>
