const router = require('express').Router();
const extractError = require('../helpers/extractError');
const shoeService = require('../services/shoeService');
const userService = require('../services/userService');
const { authenticated } = require('../middlewares/guards');

router.get('/', async (req, res, next) => {
    const loggedIn = req.user;
    try {
        if (loggedIn) {
            const shoes = await shoeService.getAll();

            res.render('user-home', { shoes });
        } else {
            res.render('guest-home');
        }
    } catch (error) {
        next(error);
    }
});

router.get('/shoe/create', authenticated, (req, res) => {
    res.render('create');
});

router.post('/shoe/create', authenticated, async (req, res) => {
    try {
        await shoeService.create({
            ...req.body,
            createdAt: Date.now(),
            creator: req.user._id,
        });

        res.redirect('/');
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        res.render('create', { error });
    }
});

router.get('/shoe/details/:shoeId', authenticated, async (req, res, next) => {
    const shoeId = req.params.shoeId;

    try {
        const shoe = await shoeService.getOne(shoeId);

        let isCreator = shoe.creator === req.user._id;
        let hasBought = shoe.buyers.some(objectId => objectId.equals(req.user._id));

        res.render('details', { shoe, isCreator, hasBought });
    } catch (error) {
        next(error);
    }
});

router.get('/shoe/edit/:shoeId', authenticated, async (req, res, next) => {
    const shoeId = req.params.shoeId;

    try {
        const shoe = await shoeService.getOne(shoeId);

        const { error } = req.session;

        if (error) {
            req.session.destroy();
            res.render('edit', { shoe, error })
        } else {
            res.render('edit', { shoe });
        }
    } catch (error) {
        next(error);
    }
});

router.post('/shoe/edit/:shoeId', authenticated, async (req, res) => {
    const shoeId = req.params.shoeId;

    try {
        await shoeService.update(shoeId, req.body);

        res.redirect(`/shoe/details/${shoeId}`);
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        req.session.error = error;

        res.redirect(`/shoe/edit/${shoeId}`);
    }
});

router.get('/shoe/buy/:shoeId', authenticated, async (req, res, next) => {
    const shoeId = req.params.shoeId;
    const userId = req.user._id;

    try {
        await shoeService.buy(shoeId, userId);

        res.redirect(`/shoe/details/${shoeId}`);
    } catch (error) {
        next(error);
    }
});

router.get('/shoe/delete/:shoeId', authenticated, async (req, res, next) => {
    const shoeId = req.params.shoeId;

    try {
        await shoeService.remove(shoeId);

        res.redirect('/');
    } catch (error) {
        next(error);
    }
});

router.get('/user/profile',  authenticated, async (req, res, next) => {
    try {
        const user = await userService.getUserInfo(req.user._id);

        const totalSum = user.offersBought.reduce((a, b) => a + b.price, 0);

        res.render('profile', { offersBought: user.offersBought, totalSum });
    } catch (error) {
        next(error);
    }
});

module.exports = router;