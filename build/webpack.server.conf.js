// const path = require('path');
// const webpack = require('webpack');
// const base = require('./webpack.base.config');
// const nodeExternals = require('webpack-node-externals');
// const ExtractTextPlugin = require('extract-text-webpack-plugin');

// const config = Object.assign({}, base, {
//   entry: path.resolve(__dirname, '../src/server-entry.js'),
//   target: 'node',
//   devtool: 'source-map',
//   output: {
//     path: path.resolve(__dirname, '../dist'),
//     filename: 'server/[name].js',
//     libraryTarget: 'commonjs2'
//   },
//   externals: nodeExternals({
//     whitelist: /\.css$/
//   }),
//   plugins: [
//     new ExtractTextPlugin('server/styles.css')
//   ]
// });

// module.exports = config;

const path = require('path')
const fs = require('fs');
// function resolve (dir) {
//   return path.join(__dirname, '..', dir)
// }


var nodeModules = {};
fs.readdirSync('node_modules')
  .filter(function(x) {
    return ['.bin'].indexOf(x) === -1;
  })
  .forEach(function(mod) {
    nodeModules[mod] = 'commonjs ' + mod;
  });

const config = {
  entry: {
    app: path.resolve(__dirname, '../src/server/app.js')
  },
  target: 'node',
  // module: {
  //   rules: [
  //     {
  //       enforce: 'pre',
  //       test: /(\.js$)/,
  //       loader: 'eslint-loader',
  //       exclude: /node_modules/
  //     },
  //     {
  //       test: /\.(ttf|eot|woff|woff2)$/,
  //       loader: 'file-loader',
  //       options: {
  //         name: 'fonts/[name].[ext]',
  //         outputPath: 'assets/'
  //       }
  //     },
  //     {
  //       test: /\.vue$/,
  //       loader: 'vue-loader',
  //       options: {
  //         css: 'css-loader',
  //         'scss': 'css-loader|sass-loader'
  //       }
  //     },
  //     {
  //       test: /\.js$/,
  //       loader: 'babel-loader',
  //       exclude: /node_modules/
  //     }
  //   ]
  // },
  output: {
    path: path.resolve(__dirname, '../dist'),
    publicPath: '/',
    filename: '[name].js'
  },
  externals: nodeModules
}

module.exports = config
