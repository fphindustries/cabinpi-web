const path = require('path')

const config = {
  entry: {
    app: path.resolve(__dirname, '../src/client-entry.js')
  },
  module: {
    rules: [
      {
        enforce: 'pre',
        test: /(\.js$)|(\.vue$)/,
        loader: 'eslint-loader',
        exclude: /node_modules/
      },
      {
        test: /\.(ttf|eot|woff|woff2)$/,
        loader: 'file-loader',
        options: {
          name: 'fonts/[name].[ext]',
          outputPath: 'assets/'
        }
      },
      {
        test: /\.vue$/,
        loader: 'vue-loader',
        options: {
          css: 'css-loader',
          'scss': 'css-loader|sass-loader'
        }
      },
      {
        test: /\.js$/,
        loader: 'babel-loader',
        exclude: /node_modules/
      }
    ]
  },
  output: {
    path: path.resolve(__dirname, '../dist'),
    publicPath: '/',
    filename: 'assets/js/[name].js'
  }
}

module.exports = config
