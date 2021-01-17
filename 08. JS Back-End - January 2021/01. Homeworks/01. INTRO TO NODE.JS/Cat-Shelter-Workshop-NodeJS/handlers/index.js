const homeHandler = require('./home');
const staticFilesHandler = require('./static-files');
const catHandler = require('./cat');
const searchHandler = require('./search');

module.exports = [homeHandler, staticFilesHandler, catHandler, searchHandler];