var webpackMerge = require('webpack-merge');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var commonConfig = require('./webpack.common.js');
var path = require('path');

module.exports = webpackMerge(commonConfig, {
  devtool: 'inline-source-map',

  output: {
    path: path.join(__dirname, '/wwwroot/'),
    publicPath: 'http://localhost:5000/',
    filename: '[name].js',
    chunkFilename: '[id].chunk.js'
  },

  plugins: [
    new ExtractTextPlugin('[name].css')
  ],

  devServer: {
    historyApiFallback: true,
    stats: 'minimal'
  }
});
