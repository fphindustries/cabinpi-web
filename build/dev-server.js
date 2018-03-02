const webpack = require('webpack');
const middleware = require('webpack-dev-middleware');
const webPackConfig = require("./webpack.dev.conf");

const express = require('express');
const app = express();

webPackConfig.then(configuration => {
  configuration.entry.app = [
    "webpack-hot-middleware/client",
    configuration.entry.app
  ];
  // configuration.plugins.push(
  //   new webpack.HotModuleReplacementPlugin(),
  //   new webpack.NoEmitOnErrorsPlugin()
  //   );

  const clientCompiler = webpack(configuration);
  app.use(
    require("webpack-dev-middleware")(clientCompiler, {
      stats: {
        colors: true
      }
    })
  );

  app.use(require("webpack-hot-middleware")(clientCompiler));

  var routes = require('../src/server/routes');
  routes(app);

  app.listen(configuration.devServer.port, () => {
  });
});
