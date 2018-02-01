'use strict';
module.exports = function (app) {
  var sensors = require('../controllers/sensorsController');

  // sensors Routes
  app.route('/sensors')
    .get(sensors.getAll);
};
