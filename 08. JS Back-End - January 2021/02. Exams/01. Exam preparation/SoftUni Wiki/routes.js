const express = require('express');

// TODO: Add controllers
const homeController = require('./controllers/homeController');
const authController = require('./controllers/authController');
const articleController = require('./controllers/articleController');

const router = express.Router();

// TODO: Set routes
router.use('/', homeController);
router.use('/auth', authController);
router.use('/article', articleController);

module.exports = router;