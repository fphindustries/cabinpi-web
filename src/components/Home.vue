<template>
<div>
  <div class="md-layout md-gutter">
    <div class="md-layout-item">
      <md-card>
        <md-card-header>
          <div class="md-title">Outside</div>
        </md-card-header>
        <md-card-content>
          {{ sensors.ext_f | formatNumber }}
        </md-card-content>
      </md-card>
    </div>
    <div class="md-layout-item">
      <md-card>
        <md-card-header>
          <div class="md-title">Inside</div>
        </md-card-header>
        <md-card-content>
          {{ sensors.int_f | formatNumber }}
        </md-card-content>
      </md-card>
    </div>
  </div>
    <div class="md-layout md-gutter">
    <div class="md-layout-item">
      <md-card>
        <md-card-header>
          <div class="md-title">Battery</div>
        </md-card-header>
        <md-card-content>
          {{ solar.dispavgVpv | formatNumber }}
        </md-card-content>
      </md-card>
    </div>
    <div class="md-layout-item">
      <md-card>
        <md-card-header>
          <div class="md-title">Battery Status</div>
        </md-card-header>
        <md-card-content>
          {{ sensors.int_f | formatNumber }}
        </md-card-content>
      </md-card>
    </div>
  </div>
</div>
</template>
<style lang="scss" scoped>
  .md-card {
    //width: 320px;
    margin: 10px;
    //display: inline-block;
    vertical-align: top;
  }
</style>
<script>
import { mapGetters } from 'vuex';

export default {
  computed: {
    ...mapGetters(['sensors', 'solar', 'forecast']),
  },
};
</script>
