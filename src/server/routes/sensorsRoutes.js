'use strict';

module.exports = function (app) {
  var sensors = require('../controllers/sensorsController');
  var forecast = require('../controllers/forecastController');

  // sensors Routes
  app.route('/api/sensors')
    .get(sensors.getSensors);
  app.route('/api/sensors/24hours')
    .get(sensors.getSensors24Hours);
  app.route('/api/solar')
    .get(sensors.getSolar);
  app.route('/api/solar/24hours')
    .get(sensors.getSolar24Hours);
  app.route('/api/forecast')
    .get(forecast.getForecast);
};
