import axios from 'axios';

axios.defaults.baseURL = '/api';

const restClient = {
  getSht31() {
    return new Promise((resolve) => {
      axios.get('/sensors/sht31')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getSht31oneDay() {
    return new Promise((resolve) => {
      axios.get('/sensors/sht31/1day')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getBmp280() {
    return new Promise((resolve) => {
      axios.get('/sensors/bmp280')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getDs18b20() {
    return new Promise((resolve) => {
      axios.get('/sensors/ds18b20')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getIna219() {
    return new Promise((resolve) => {
      axios.get('/sensors/ina219')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getForecast() {
    return new Promise((resolve) => {
      axios.get('/forecast')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
};

export default restClient;
