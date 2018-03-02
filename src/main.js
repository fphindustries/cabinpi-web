// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue';
import VueTimers from 'vue-timers';
import VueMaterial from 'vue-material';
import 'vue-material/dist/vue-material.min.css';
import 'vue-material/dist/theme/default.css';
import store from './vuex/index';
import App from './App';
import router from './router';
import formatNumberFilter from './filters/formatNumberFilter';

Vue.filter('formatNumber', formatNumberFilter);
Vue.use(VueTimers);
Vue.use(VueMaterial);
Vue.config.productionTip = false;

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>',
  store,
});
