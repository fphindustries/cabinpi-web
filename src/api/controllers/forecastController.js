'use strict';

const moment = require('moment');
const noaaForecaster = require('noaa-forecasts');
const config = require('config');

//const telgrafConfig = config.get('telegraf');

exports.getForecast = function (req, res) {
  var obj = {
    listLatLon: '47.15,-120.9152',
    product: 'time-series', // this is a default, it's not actually required
    begin: moment().format('YYYY-MM-DDTHH:mm:ss'),
    end: moment().add(3, 'days').format('YYYY-MM-DDTHH:mm:ss'),
    //qpf: 'qpf', // first elementInputName - Liquid Precipitation Amount
    //pop12: 'pop12', // another elementInputName - 12 hour probability of precipitation,
    wx: 'wx',
    icons: 'icons'
  };

  var token = 'TEXpzSWHQrwsAwxfUZziuKVIAzNTPoqg';
  noaaForecaster.setToken(token);
  noaaForecaster.getForecast(obj)
    .then(forecast => {
      res.json(forecast);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};
