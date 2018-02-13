import Vue from 'vue';
import VueTimers from 'vue-timers';
import store from './vuex/index';
import App from './App.vue';
import router from './router';
import formatNumberFilter from './filters/formatNumberFilter';

Vue.filter('formatNumber', formatNumberFilter);
Vue.use(VueTimers);
// const app = new Vue({
//   router,
//   ...AppLayout,
//   store,
// });
// export { app, router, store };

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>',
  store,
});
