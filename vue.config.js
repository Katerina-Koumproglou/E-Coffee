const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  devServer: {
    historyApiFallback: true,
    },
    publicPath: process.env.NODE_ENV === 'production' ? '/E-Coffee/' : '/',
})
