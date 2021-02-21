const router = require('express').Router();
const { authenticated } = require('../middlewares/guards');

// routes
router.get('/', (req, res) => {
    const loggedIn = req.user;

    if (!loggedIn) {
        res.render('guest-home');
    } else {
        res.render('user-home');
    }
});

module.exports = router;