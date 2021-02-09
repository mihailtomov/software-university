const express = require('express');
const handlebars = require('express-handlebars');
const cookieParser = require('cookie-parser');
const auth = require('../middlewares/auth');
const path = require('path');

module.exports = (app) => {
    app.engine('hbs', handlebars({
        extname: 'hbs',
        layoutsDir: path.join(__dirname, '../views/layouts'),
        defaultLayout: 'main',
    }));

    app.set('view engine', 'hbs');

    app.set('views', [
        path.join(__dirname, '../views/home pages'),
        path.join(__dirname, '../views/booking pages'),
        path.join(__dirname, '../views/user pages'),
    ]);

    app.use(express.static('static'));

    app.use(express.urlencoded({ extended: true }));

    app.use(cookieParser());

    app.use(auth());
}