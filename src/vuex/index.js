import Vue from 'vue';
import Vuex from 'vuex';
import restClient from '../services/restClient';

Vue.use(Vuex);

const state = {
  sensors: {},
  solar: {},
  forecast: {},
  sensors24Hours: {},
  solar24Hours: {},
};

const store = new Vuex.Store({
  state,
  getters: {
    sensors: s => s.sensors,
    solar: s => s.solar,
    forecast: s => s.forecast,
    sensors24Hours: s => s.sensors24Hours,
    solar24Hours: s => s.solar24Hours,
  },
  actions: {
    refreshSensors(context) {
      restClient.getSensors().then((data) => {
        context.commit('updateSensors', data);
      });
      restClient.getSolar().then((data) => {
        context.commit('updateSolar', data);
      });
    },
    refreshForecast(context) {
      restClient.getForecast().then((data) => {
        context.commit('refreshForecast', data);
      });
    },
    refreshCharts(context) {
      restClient.getSensors24Hours().then((data) => {
        context.commit('updateSensors24Hours', data);
      });
      restClient.getSolar24Hours().then((data) => {
        context.commit('updateSolar24Hours', data);
      });
    },
  },
  mutations: {
    updateSensors(s, sensors) {
      s.sensors = sensors; // eslint-disable-line no-param-reassign
    },
    updateSolar(s, solar) {
      s.solar = solar; // eslint-disable-line no-param-reassign
    },
    refreshForecast(s, forecast) {
      s.forecast = forecast; // eslint-disable-line no-param-reassign
    },
    updateSensors24Hours(s, sensors24Hours) {
      s.sensors24Hours = sensors24Hours; // eslint-disable-line no-param-reassign
    },
    updateSolar24Hours(s, solar24Hours) {
      s.solar24Hours = solar24Hours; // eslint-disable-line no-param-reassign
    },
  },
});

export default store;
