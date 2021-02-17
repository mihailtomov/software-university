const express = require('express');

const courseController = require('./controllers/courseController');
const authController = require('./controllers/authController');

const router = express.Router();

router.use('/', courseController);
router.use('/auth', authController);

module.exports = router;