<template>
  <div class="page-container" id="app">
    <md-app>
      <md-app-toolbar class="md-primary">
        <span class="md-title">My Title</span>
      </md-app-toolbar>
  <md-app-drawer md-permanent="full">
    <md-toolbar class="md-transparent" md-elevation="0">
      Navigation
    </md-toolbar>
    <md-list>
      <md-list-item>
          <md-icon>move_to_inbox</md-icon>
        <router-link class="md-list-item-text" to="/" exact="" data-label="Home">Home
        </router-link>
      </md-list-item>

      <md-list-item>
          <md-icon>send</md-icon>
        <router-link class="md-list-item-text" to="/environment" exact="" data-label="Environment">
          Environment
        </router-link>
      </md-list-item>

      <md-list-item>
          <md-icon>delete</md-icon>
        <router-link class="md-list-item-text" to="/power" exact="" data-label="Power">
          Power
        </router-link>
      </md-list-item>

      <md-list-item>
          <md-icon>error</md-icon>
        <router-link class="md-list-item-text" to="/forecast" exact="" data-label="Forecast">
          Forecast
        </router-link>
      </md-list-item>
    </md-list>
  </md-app-drawer>

      <md-app-content>
        <router-view></router-view>
      </md-app-content>
    </md-app>
  </div>
</template>
<script>
import { mapActions } from 'vuex';
import AppHeader from './components/AppHeader';
import AppFooter from './components/AppFooter';

let self = this;

export default {
  components: {
    'app-header': AppHeader,
    'app-footer': AppFooter,
  },
  timers: {
    sensorTimer: {
      time: 60000,
      autostart: true,
      repeat: true,
      immediate: true,
    },
    forecastTimer: {
      time: 1800000, // 30 minutes
      autostart: true,
      repeat: true,
      immediate: true,
    },
    chartTimer: {
      time: 300000, // 5 minutes
      autostart: true,
      repeat: true,
      immediate: true,
    },
  },
  data() {
    return {
      timer: {},
    };
  },
  methods: {
    ...mapActions({
      refreshSensors: 'refreshSensors',
      refreshForecast: 'refreshForecast',
      refreshCharts: 'refreshCharts',
    }),
    sensorTimer: () => {
      self.refreshSensors();
    },
    forecastTimer: () => {
      self.refreshForecast();
    },
    chartTimer: () => {
      self.refreshCharts();
    },
  },
  created() {
    self = this;
  },
};
</script>
<style lang="scss" scoped>
  .md-app {
    //max-height: 400px;
    border: 1px solid rgba(#000, .12);
  }

  //  // Demo purposes only
  // .md-drawer {
  //   width: 230px;
  //   max-width: calc(100vw - 125px);
  // }
</style>
