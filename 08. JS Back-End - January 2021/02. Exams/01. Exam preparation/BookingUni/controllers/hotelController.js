const router = require('express').Router();
const { authenticated } = require('../middlewares/guards');
const hotelService = require('../services/hotelService');

router.get('/', async (req, res) => {
    try {
        const hotels = await hotelService.getAll();

        res.render('home', { hotels });
    } catch (error) {
        console.log(error);
    }
});

router.get('/hotel/create', authenticated, (req, res) => {
    res.render('create');
});

router.post('/hotel/create', authenticated, async (req, res) => {
    try {
        await hotelService.create({ owner: req.user.username, ...req.body });

        res.redirect('/');
    } catch (error) {
        console.log(error);
    }
});

router.get('/hotel/details/:hotelId', authenticated, async (req, res) => {
    try {
        const hotel = await hotelService.getOne(req.params.hotelId);

        res.render('details', { hotel });
    } catch (error) {
        console.log(error);
    }
});

module.exports = router;