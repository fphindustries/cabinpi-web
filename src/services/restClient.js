import axios from 'axios';

axios.defaults.baseURL = '/api';

const restClient = {
  getSensors() {
    return new Promise((resolve) => {
      axios.get('/sensors')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getSensors24Hours() {
    return new Promise((resolve) => {
      axios.get('/sensors/24hours')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getSolar() {
    return new Promise((resolve) => {
      axios.get('/solar')
        .then((response) => {
          resolve(response.data);
        });
    });
  },
  getSolar24Hours() {
    return new Promise((resolve) => {
      axios.get('/solar/24hours')
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
