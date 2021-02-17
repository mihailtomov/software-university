const express = require('express');
const hotelController = require('./controllers/hotelController');
const authController = require('./controllers/authController');
const profileController = require('./controllers/profileController');

const router = express.Router();

router.use('/', hotelController);
router.use('/auth', authController);
router.use('/profile', profileController);

module.exports = router;