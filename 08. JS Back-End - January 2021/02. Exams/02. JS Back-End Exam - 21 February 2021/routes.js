const express = require('express');

const expenseController = require('./controllers/expenseController');
const authController = require('./controllers/authController');

const router = express.Router();

router.use('/', expenseController);
router.use('/auth', authController);
router.get('*', (req, res) => {
    res.status(404).render('notFound');
});

module.exports = router;