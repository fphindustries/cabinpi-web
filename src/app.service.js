import axios from 'axios';

axios.defaults.baseURL = 'http://localhost:3000';

const appService = {
  getSensors () {
    return new Promise((resolve) => {
      axios.get('/sensors')
        .then(response => {
          resolve(response.data);
        });
    });
  }
};

export default appService;
