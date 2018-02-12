const axios = require('axios');
const config = require('config');

axios.defaults.baseURL = 'https://api.darksky.net/forecast/';
const darkskyConfig = config.get('darksky');

exports.getForecast = function getForecast(req, res) {
  axios.get(`${darkskyConfig.key}/${darkskyConfig.latitude},${darkskyConfig.longitude}?exclude=minutely`)
    .then((response) => {
      res.json(response.data);
    }).catch((err) => {
      res.status(500).send(err.stack);
    });
};
