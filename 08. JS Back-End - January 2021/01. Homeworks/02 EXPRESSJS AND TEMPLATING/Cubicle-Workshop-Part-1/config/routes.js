const mainPage = require('../controllers/mainPage');
const aboutPage = require('../controllers/aboutPage');
const createPage = require('../controllers/createPage');
const detailsPage = require('../controllers/detailsPage');
const notFoundPage = require('../controllers/notFoundPage');
const addCubicle = require('../controllers/addCubicle');
const searchHandler = require('../controllers/searchHandler');

module.exports = (app) => {
    app.get('/', mainPage);
    app.get('/about', aboutPage);
    app.get('/create', createPage);
    app.get('/details/:id', detailsPage);

    app.post('/create', addCubicle);
    app.post('/search', searchHandler);

    app.all('*', notFoundPage);
};