'use strict';

const Influx = require('influx');
const config = require('config');

const telgrafConfig = config.get('telegraf');

const influx = new Influx.InfluxDB(telgrafConfig);

exports.getSensors = function (req, res) {
  influx.query('select * from sensors group by * order by desc limit 1')
    .then(queryResult => {
      res.json(queryResult[0]);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};

exports.getSensors24Hours = function (req, res) {
  influx.query('select mean(case_c) AS case_c, mean(case_f) AS case_f, mean(ext_c) as ext_c, mean(ext_f) as ext_f, mean(hPa) as hPa, mean(humidity) as humidity, mean(inHg) as inHg, mean(int_c) as int_c, mean(int_f) as int_f, mean(pi_i) as pi_i, mean(pi_v) as pi_v, mean(pi_w) as pi_w from sensors where time > now() - 1d group by time(1h)')
    .then(queryResult => {
      res.json(queryResult);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};

exports.getSolar = function (req, res) {
  influx.query('select * from solar group by * order by desc limit 1')
    .then(queryResult => {
      res.json(queryResult[0]);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};

exports.getSolar24Hours = function (req, res) {
  influx.query('select mean(AbsorbTime) as AbsorbTime, mean(AmpHours) as AmpHours, mean(EqualizeTime) as EqualizeTime, mean(FloatTime) as FloatTime, mean(HighestVinputLog) as HighestVinputLog, mean(IbattDisplay) as IbattDisplay, mean(NiteMinutesNoPwr) as NiteMinutesNoPwr, mean(PvInputCurrent) as PvInputCurrent, mean(VocLastMeasured) as VocLastMeasured, mean(chargeState) as chargeState, mean(dispavgVbatt) as dispavgVbatt, mean(dispavgVpv) as dispavgVpv, mean(kWHours) as kWHours, mean(watts) as watts from solar where time > now() - 1d group by time(1h)')
    .then(queryResult => {
      res.json(queryResult);
    }).catch(err => {
      res.status(500).send(err.stack);
    });
};
