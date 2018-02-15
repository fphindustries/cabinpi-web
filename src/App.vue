<template>
  <div class="wrapper row flexh" id="app">
      <!--Left Column-->
      <!--Main Frame-->
      <div class="wrapper column flexv flexch" id="wpr_mainView">
          <!--Header-->
          <div id="terminal-framing" class="row flexh" style="height:60px;">
              <div class="elbow top-left bg-blue-3 large no-event horizontal" id="elbow_196" style="width:250px; height:208px;">
                  <div class="bar">
                      <div class="block"></div>
                  </div>
              </div>
              <div class="bar flexch bg-blue-3" id="bar_197"></div>
              <div id="title_198" class="title text-blue-1">CabinPi</div>
              <div class="cap bg-green-2 right" id="cap_199" style="margin-left:10px;"></div>
          </div>
          <!--Main Content Row-->
          <div class="row flexh fexcv" style="margin-top: 0px;">
              <app-header></app-header>
              <div class="column flexch flexv" style="margin-top:40px; margin-left:40px; margin-right: 40px;">
                      <div class="row header flexh" id="row_2">
                        <router-view></router-view>
                      </div>
              </div>
          </div>
      </div>
  </div>
</template>
<script>
import { mapActions } from 'vuex';
import AppHeader from './components/AppHeader.vue';
import AppFooter from './components/AppFooter.vue';

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
<style lang="scss">
  @import './assets/css/lcarssdk.css';
    @import './assets/css/scrollbutton.css';
    @import './assets/css/levelbar.css';
    @import './assets/css/bracket.css';
    @import './assets/css/dialog.css';
    @import './assets/css/framing.css';
    @import './assets/css/button.css';
    @import './assets/css/theme_ussNotAffiliated.css';
    @import './assets/css/module.css';
  //$primary: #287ab1;
  //@import '~bulma';

  .columns{
    flex-wrap: wrap
  }
</style>
