const router = require('express').Router();
const { authenticated } = require('../middlewares/guards');
const extractError = require('../helpers/extractError');
const expenseService = require('../services/expenseService');

router.get('/', async (req, res, next) => {
    try {
        const loggedIn = req.user;

        if (!loggedIn) {
            res.render('guest-home');
        } else {
            const expenses = await expenseService.getAllByUser(req.user._id);

            const { error, success } = req.session;

            if (error) {
                res.render('user-home', { expenses, error });
                req.session.destroy();
            } else if(success){
                res.render('user-home', {expenses, success});
                req.session.destroy();
            } else {
                res.render('user-home', { expenses });
            }
        }
    } catch (error) {
        next(error);
    }
});

router.get('/expense/create', authenticated, (req, res) => {
    res.render('create');
});

router.post('/expense/create', authenticated, async (req, res) => {
    const userId = req.user._id;

    try {
        await expenseService.create({ ...req.body, creator: userId }, userId);

        res.redirect('/');
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        res.render('create', { error });
    }
});

router.get('/expense/details/:expenseId', authenticated, async (req, res, next) => {
    const expenseId = req.params.expenseId;

    try {
        const expense = await expenseService.getOne(expenseId);

        res.render('details', { expense });
    } catch (error) {
        next(error);
    }
});

router.get('/expense/delete/:expenseId', authenticated, async (req, res, next) => {
    const expenseId = req.params.expenseId;

    try {
        const expense = await expenseService.getOne(expenseId);

        if (expense.creator.equals(req.user._id)) {
            await expenseService.remove(expenseId);

            res.redirect('/');
        } else {
            res.redirect('/');
        }
    } catch (error) {
        next(error);
    }
});

router.post('/expense/refill', authenticated, async (req, res) => {
    try {
        await expenseService.refill(req.user._id, req.body);

        req.session.success = { message: 'You refilled your account successfully!' };

        res.redirect('/');
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        req.session.error = error;

        res.redirect('/');
    }
});

router.get('/user/profile', async (req, res, next) => {
    try {
        const userInfo = await expenseService.getProfileInfo(req.user._id);

        console.log(userInfo);
    } catch (error) {
        next(error);
    }
});

module.exports = router;