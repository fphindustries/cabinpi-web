<template>

      <div id="App" class="page-container">
        <md-app>
          <md-app-content>
        <router-view></router-view>
      <md-bottom-bar md-sync-route>
        <md-bottom-bar-item to="/" md-label="Home" md-icon="home"></md-bottom-bar-item>
        <md-bottom-bar-item to="/environment" md-label="Posts" md-icon="favorite"></md-bottom-bar-item>
        <md-bottom-bar-item to="/power" md-label="Favorites" md-icon="favorite"></md-bottom-bar-item>
        <md-bottom-bar-item to="/forecast" md-label="Favorites" md-icon="favorite"></md-bottom-bar-item>
        <md-bottom-bar-item to="/camera" md-label="Favorites" md-icon="favorite"></md-bottom-bar-item>
      </md-bottom-bar>
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
