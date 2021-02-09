const express = require('express');
const hotelController = require('./controllers/hotelController');
const authController = require('./controllers/authController');

const router = express.Router();

router.use('/', hotelController);
router.use('/auth', authController);

module.exports = router;