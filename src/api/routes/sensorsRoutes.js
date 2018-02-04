'use strict';
module.exports = function (app) {
  var sensors = require('../controllers/sensorsController');
  var forecast = require('../controllers/forecastController');

  // sensors Routes
  app.route('/sensors/sht31')
    .get(sensors.getSht31);
  app.route('/sensors/bmp280')
    .get(sensors.getBmp280);
  app.route('/sensors/ds18b20')
    .get(sensors.getDs18b20);
  app.route('/sensors/ina219')
    .get(sensors.getIna219);
  app.route('/forecast')
    .get(forecast.getForecast);
};
