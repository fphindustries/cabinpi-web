'use strict';

const Influx = require('influx');
const config = require('config');

const telgrafConfig = config.get('telegraf');

const influx = new Influx.InfluxDB(telgrafConfig);

exports.getSht31 = function (req, res) {
  influx.query(`select * from sht31 group by * order by desc limit 1`)
    .then(queryResult => {
      res.json(queryResult[0]);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};

exports.getBmp280 = function (req, res) {
  influx.query(`select * from bmp280 group by * order by desc limit 1`)
    .then(queryResult => {
      res.json(queryResult[0]);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};

exports.getDs18b20 = function (req, res) {
  influx.query(`select * from ds18b20 group by * order by desc limit 1`)
    .then(queryResult => {
      res.json(queryResult[0]);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};

exports.getIna219 = function (req, res) {
  influx.query(`select * from ina219 group by * order by desc limit 1`)
    .then(queryResult => {
      res.json(queryResult[0]);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};
