const express = require('express');

const theaterController = require('./controllers/theaterController');
const authController = require('./controllers/authController');

const router = express.Router();

router.use('/', theaterController);
router.use('/auth', authController);

module.exports = router;