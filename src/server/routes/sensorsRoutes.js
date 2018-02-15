'use strict';

module.exports = function (app) {
  var sensors = require('../controllers/sensorsController');
  var forecast = require('../controllers/forecastController');

  // sensors Routes
  app.route('/api/sensors/sht31')
    .get(sensors.getSht31);
  app.route('/api/sensors/bmp280')
    .get(sensors.getBmp280);
  app.route('/api/sensors/ds18b20')
    .get(sensors.getDs18b20);
  app.route('/api/sensors/ina219')
    .get(sensors.getIna219);
  app.route('/api/forecast')
    .get(forecast.getForecast);
  app.route('/api/sensors/sht31/1day')
    .get(sensors.getSht31_1Day);
};
