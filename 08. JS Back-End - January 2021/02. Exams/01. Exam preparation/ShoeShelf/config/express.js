const express = require('express');
const handlebars = require('express-handlebars');
const cookieParser = require('cookie-parser');
const session = require('express-session');
const auth = require('../middlewares/auth');
const path = require('path');

module.exports = (app) => {
    app.engine('hbs', handlebars({
        extname: 'hbs',
        layoutsDir: path.join(__dirname, '../views/layouts'),
        partialsDir: path.join(__dirname, '../views/partials'),
        defaultLayout: 'main',
    }));

    app.set('view engine', 'hbs');

    app.set('views', [
        path.join(__dirname, '../views/home pages'),
        path.join(__dirname, '../views/user pages'),
        path.join(__dirname, '../views/shoes pages'),
    ]);

    app.use(express.static('public'));

    app.use(express.urlencoded({ extended: true }));

    app.use(cookieParser());

    app.use(session({
        secret: 'test',
        resave: false,
        saveUninitialized: true,
        cookie: { secure: false }
    }));

    app.use(auth());
}