<template>
  <div class="wrapper content flexcv">
    <div class="row flexh">
      <div class="column">
        <h3 class="text-green-3">OUTSIDE</h3>
      </div>
      <div class="column">
        <h1 class="text-green-2">{{ sensors.ext_f | formatNumber }}</h1>
      </div>
      <div class="column">
        <h3 class="text-green-3">INSIDE</h3>
      </div>
      <div class="column">
        <h1 class="text-green-2">{{ sensors.int_f | formatNumber }}</h1>
      </div>
    </div>
    <div class="row flexh">
      <div class="column">
        <h3 class="text-green-3">HUMIDITY</h3>
      </div>
      <div class="column">
        <h3 class="text-green-2">{{ sensors.humidity | formatNumber }}</h3>
      </div>
      <div class="column">
        <h3 class="text-green-3">PRESSURE</h3>
      </div>
      <div class="column">
        <h3 class="text-green-2">{{ sensors.inHg | formatNumber }}</h3>
      </div>
      <div class="column">
        <h3 class="text-green-3">CASE TEMP</h3>
      </div>
      <div class="column">
        <h3 class="text-green-2">{{ sensors.case_f }}</h3>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  computed: {
    ...mapGetters(['sensors']),
  },
};
</script>
