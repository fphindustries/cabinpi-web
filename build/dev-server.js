const webpack = require('webpack');
const middleware = require('webpack-dev-middleware');
const webPackConfig = require("./webpack.dev.conf");

const express = require('express');
const app = express();

webPackConfig.then(configuration => {
  const clientCompiler = webpack(configuration);
  app.use(
    require("webpack-dev-middleware")(clientCompiler, {
      stats: {
        colors: true
      }
    })
  );

  var routes = require('../src/server/routes');
  routes(app);

  app.listen(configuration.devServer.port, () => {
  });
});
