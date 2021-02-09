const router = require('express').Router();
const authService = require('../services/authService');
const { guest, authenticated } = require('../middlewares/guards');

router.get('/register', guest, (req, res) => {
    res.render('register');
});

router.post('/register', guest, async (req, res) => {
    try {
        const token = await authService.register(req.body);

        res.cookie('AUTH', token);
        res.redirect('/');
    } catch (error) {
        res.render('register', { error })
    }
});

router.get('/login', guest, (req, res) => {
    res.render('login');
});

router.post('/login', guest, async (req, res) => {
    try {
        const token = await authService.login(req.body);

        res.cookie('AUTH', token);
        res.redirect('/');
    } catch (error) {
        res.render('login', { error });
    }
});

router.get('/logout', authenticated, (req, res) => {
    res.clearCookie('AUTH');

    res.redirect('/');
})

module.exports = router;