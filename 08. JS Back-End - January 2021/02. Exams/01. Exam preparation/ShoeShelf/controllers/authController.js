const router = require('express').Router();
const { AUTH_COOKIE } = require('../config/init');
const authService = require('../services/authService');
const { guest, authenticated } = require('../middlewares/guards');

router.get('/register', guest, (req, res) => {
    res.render('register');
});

router.post('/register', guest, async (req, res) => {
    try {
        await authService.register(req.body);
        
        const { email, password } = req.body;
        const token = await authService.login({ email, password });

        res.cookie(AUTH_COOKIE, token);
        res.redirect('/');
    } catch (error) {
        res.render('register', { error });
    }
});

router.get('/login', guest, (req, res) => {
    res.render('login');
});

router.post('/login', guest, async (req, res) => {
    try {
        const token = await authService.login(req.body);

        res.cookie(AUTH_COOKIE, token);
        res.redirect('/');
    } catch (error) {
        res.render('login', { error });
    }
});

router.get('/logout', authenticated, (req, res) => {
    res.clearCookie(AUTH_COOKIE);

    res.redirect('/auth/login');
})

module.exports = router;