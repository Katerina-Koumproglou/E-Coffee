const { defineConfig } = require('@vue/cli-service');

module.exports = defineConfig({
    transpileDependencies: true,
    devServer: {
	host: '83.212.99.172',
	port: 80,
        historyApiFallback: true,
        allowedHosts: [
            '83.212.99.172',  // Add the IP or domain you want to allow
            'ecoffee.dns.army',     // If you want to use a custom domain
        ],

    },
    publicPath: './',
});
