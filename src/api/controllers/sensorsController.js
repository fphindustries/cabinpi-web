'use strict';

exports.getAll = function (req, res) {
  const result = { interiorTemp: 68.2, exteriorTemp: 32.4 };

  res.json(result);
};
