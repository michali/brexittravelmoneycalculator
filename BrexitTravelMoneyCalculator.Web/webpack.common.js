var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var path = require('path');
var CleanWebpackPlugin = require('clean-webpack-plugin');

module.exports = {
  entry: {
    'polyfills': './scripts/polyfills.ts',
    'vendor': './scripts/vendor.ts',
    'app': './scripts/app/main.ts',
    'styles': './scripts/app/styles.css',
  },
  output: {
    filename: '[name].js',
    publicPath: "/js/",
    path: path.join(__dirname, '/wwwroot/')
  },
  module: {
    rules: [
      {
        test: /\.ts$/,
        loaders: ['awesome-typescript-loader', 'angular2-template-loader']
      },
      {
        test: /\.html$/,
        loader: 'html-loader'
      },
      // { 
      //    test: /\.scss$/, 
      //    loaders: ['style', 'css', 'postcss', 'sass'] 
      // },
      {
        test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
        loader: 'file-loader?name=assets/[name].[ext]'
      },
      // { 
      //   test: /bootstrap\/dist\/js\/umd\//, 
      //   loader: 'imports?jQuery=jquery' 
      // },
      {
        test: /\.css$/,
        exclude: path.join(__dirname, '/scripts/app/'),
        loader: ExtractTextPlugin.extract({ fallbackLoader: 'style-loader', loader: 'css-loader?sourceMap' })
      },
      {
        test: /\.css$/,
        include: path.join(__dirname, '/scripts/app/'),
        loader: 'raw-loader'
      }
    ]
  },
  resolve: {
    extensions: [".tsx", ".ts", ".js"]
  },
  plugins: [
    // Workaround for angular/angular#11580
    new webpack.ContextReplacementPlugin(
      // The (\\|\/) piece accounts for path separators in *nix and Windows
      /angular(\\|\/)core(\\|\/)@angular/,
      path.join(__dirname, '/scripts/'), // location of your src
      {} // a map of your routes
    ),

    // new webpack.optimize.CommonsChunkPlugin({
    //   name: ['app', 'vendor', 'polyfills']
    // }),

    new HtmlWebpackPlugin({
     //   template: 'scripts/app/index.html'
        template: 'Views/Home/Index.cshtml',
        chunksSortMode: packageSort(['polyfills', 'vendor', 'app', 'styles'])
    }),

    new CleanWebpackPlugin(['./wwwroot/']),

    new webpack.ProvidePlugin({   
        jQuery: 'jquery',
        $: 'jquery',
        jquery: 'jquery'
    })
  ]
};

function packageSort(packages) {
    return function sort(left, right) {
        var leftIndex = packages.indexOf(left.names[0]);
        var rightindex = packages.indexOf(right.names[0]);

        if (leftIndex < 0 || rightindex < 0) {
            throw "unknown package";
        }

        if (leftIndex > rightindex) {
            return 1;
        }

        return -1;
    }
};