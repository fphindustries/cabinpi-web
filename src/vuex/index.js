import Vue from 'vue';
import Vuex from 'vuex';
import restClient from '../services/restClient';

Vue.use(Vuex);

const state = {
  sht31: {},
  bmp280: {},
  ds18b20: {},
  ina219: {},
  forecast: {},
  sht31oneDay: {},
};

const store = new Vuex.Store({
  state,
  getters: {
    sht31: s => s.sht31,
    bmp280: s => s.bmp280,
    ds18b20: s => s.ds18b20,
    ina219: s => s.ina219,
    forecast: s => s.forecast,
    sht31oneDay: s => s.sht31oneDay,
  },
  actions: {
    refreshSensors(context) {
      restClient.getBmp280().then((data) => {
        context.commit('updateBmp280', data);
      });
      restClient.getDs18b20().then((data) => {
        context.commit('updateDs18b20', data);
      });
      restClient.getIna219().then((data) => {
        context.commit('updateIna219', data);
      });
      restClient.getSht31().then((data) => {
        context.commit('updateSht31', data);
      });
    },
    refreshForecast(context) {
      restClient.getForecast().then((data) => {
        context.commit('refreshForecast', data);
      });
    },
    refreshCharts(context) {
      restClient.getSht31oneDay().then((data) => {
        context.commit('updateSht31oneDay', data);
      });
    },
  },
  mutations: {
    updateSht31(s, sht31) {
      s.sht31 = sht31; // eslint-disable-line no-param-reassign
    },
    updateBmp280(s, bmp280) {
      s.bmp280 = bmp280; // eslint-disable-line no-param-reassign
    },
    updateDs18b20(s, ds18b20) {
      s.ds18b20 = ds18b20; // eslint-disable-line no-param-reassign
    },
    updateIna219(s, ina219) {
      s.ina219 = ina219; // eslint-disable-line no-param-reassign
    },
    refreshForecast(s, forecast) {
      s.forecast = forecast; // eslint-disable-line no-param-reassign
    },
    updateSht31oneDay(s, sht31oneDay) {
      s.sht31oneDay = sht31oneDay; // eslint-disable-line no-param-reassign
    },
  },
});

export default store;
