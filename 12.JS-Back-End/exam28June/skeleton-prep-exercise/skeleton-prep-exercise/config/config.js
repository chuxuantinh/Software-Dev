module.exports = {
    development: {
        port: process.env.PORT || 4000,
        privateKey: 'SOFT-UNI-WORKSHOP',
        databaseUrl: `mongodb://localhost:27017/Theater`
    },
    production: {}
};