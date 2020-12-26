const env = process.env.NODE_ENV || 'development';
const app = require('express')();

require('./config/express')(app).then(() => {
    require('./models/user');

    const config = require('./config/config')[env];
    
    require('./config/routes')(app);
    
    app.use(function(err, req, res, next) {
    
    });
    app.listen(config.port, console.log(`Listening on port ${config.port}! Now its up to you...`));
});

