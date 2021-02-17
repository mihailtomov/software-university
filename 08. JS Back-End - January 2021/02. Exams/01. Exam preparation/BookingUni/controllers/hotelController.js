const router = require('express').Router();
const { authenticated } = require('../middlewares/guards');
const hotelService = require('../services/hotelService');

router.get('/', async (req, res) => {
    try {
        const hotels = await hotelService.getAll();
        const user = req.user;

        let loggedIn;

        user ? loggedIn = true : loggedIn = false;

        const { success } = req.session;

        if (success) {
            res.render('home', { hotels, loggedIn, success });
            req.session.destroy();
        } else {
            res.render('home', { hotels, loggedIn });
        }

    } catch (error) {
        console.log(error);
    }
});

router.get('/hotel/create', authenticated, (req, res) => {
    res.render('create');
});

router.post('/hotel/create', authenticated, async (req, res) => {
    const userId = req.user._id;

    try {
        await hotelService.create({ owner: req.user.username, ...req.body }, userId);

        req.session.success = { message: 'Created successfully!' };

        res.redirect('/');
    } catch (error) {
        res.render('create', { error });
    }
});

router.get('/hotel/details/:hotelId', authenticated, async (req, res) => {
    try {
        const hotel = await hotelService.getOne(req.params.hotelId);
        const { _id: userId, username } = req.user;

        let isBooked;
        let owner;

        hotel.bookedUsers.some(id => id == userId) ? isBooked = true : isBooked = false;
        hotel.owner === username ? owner = true : owner = false;

        const { success } = req.session;

        if (success) {
            res.render('details', { hotel, isBooked, owner, success });
            req.session.destroy();
        } else {
            res.render('details', { hotel, isBooked, owner });
        }

    } catch (error) {
        console.log(error);
    }
});

router.get('/hotel/book/:hotelId', authenticated, async (req, res) => {
    const hotelId = req.params.hotelId;

    try {
        await hotelService.book(hotelId, req.user._id);

        res.redirect(`/hotel/details/${hotelId}`);
    } catch (error) {
        console.log(error);
    }
});

router.get('/hotel/edit/:hotelId', authenticated, async (req, res) => {
    try {
        const hotel = await hotelService.getOne(req.params.hotelId);

        const { error } = req.session;

        if (error) {
            res.render('edit', { hotel, error });
            req.session.destroy();
        } else {
            res.render('edit', { hotel });
        }
    } catch (error) {
        console.log(error);
    }
});

router.post('/hotel/edit/:hotelId', authenticated, async (req, res) => {
    const hotelId = req.params.hotelId;

    try {
        await hotelService.update(hotelId, req.body);

        req.session.success = { message: 'Edited successfully!' };

        res.redirect(`/hotel/details/${hotelId}`);
    } catch (error) {
        req.session.error = error;

        res.redirect(`/hotel/edit/${hotelId}`);
    }
});

router.get('/hotel/remove/:hotelId', authenticated, async (req, res) => {
    try {
        await hotelService.deleteOne(req.params.hotelId);

        req.session.success = { message: 'Removed successfully!' };

        res.redirect('/');
    } catch (error) {
        console.log(error);
    }
});

module.exports = router;