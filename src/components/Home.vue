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
        <h3 class="text-green-3">PRESSURE</h3>
      </div>
      <div class="column">
        <h3 class="text-green-2">{{ sensors.ext_f }}</h3>
      </div>
    </div>
    <div class="row flexh" v-for="alert in forecast.alerts" :key="alert.time">
      <div class="wrapper template sdk dialog typeA flexv" style="width:100%;">
        <div class="row header flexh">
          <div class="cap medium left bg- red-dark-light"></div>
          <div class="title half">{{alert.title}}</div>
          <div class="bar flexch bg- red-dark-light" ></div>
          <div class="cap medium right bg- red-dark-light"></div>
        </div>
        <div class="content flexcv" >
          <p class="htmlTag text-green-2">{{alert.description}}</p>
        </div>
        <div class="row footer flexh">
          <div class="cap medium left bg-"></div>
          <div class="bar flexch bg-"></div>
          <div class="title half bg-"></div>
          <div class="cap medium right bg-"></div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  computed: {
    ...mapGetters(['sensors', 'solar', 'forecast']),
  },
};
</script>
