const express = require('express');
const path = require('path');
const handlebars = require('express-handlebars');
const mongos = require('../mongos');

module.exports = (app) => {
    
    app.engine('.hbs', handlebars({ extname: '.hbs' }));
    app.set('view engine', '.hbs');

    app.use(express.urlencoded({ extended: true }));
    const staticFilePath = path.resolve('./static')
    app.use(express.static(staticFilePath));

    return mongos.connect('mongodb://127.0.0.1:27017/softuni');
};