const router = require('express').Router();
const theaterService = require('../services/theaterService');
const extractError = require('../helpers/extractError');
const { authenticated } = require('../middlewares/guards');

router.get('/', async (req, res) => {
    const loggedIn = req.user;

    try {
        if (loggedIn) {
            const plays = await theaterService.getAllAuth();

            res.render('user-home', { plays });
        } else {
            const plays = await theaterService.getAllGuest();

            res.render('guest-home', { plays });
        }
    } catch (error) {
        console.log(error);
    }
});

router.get('/theater/create', authenticated, (req, res) => {
    res.render('create');
});

router.post('/theater/create', authenticated, async (req, res) => {
    try {
        await theaterService.create({ ...req.body, createdAt: Date.now(), creator: req.user.username });

        res.redirect('/');
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        res.render('create', { error });
    }
});

router.get('/theater/details/:playId', authenticated, async (req, res) => {
    const playId = req.params.playId;

    try {
        const play = await theaterService.getOne(playId);

        let creator;
        let hasLiked;

        req.user.username === play.creator ?
            creator = true :
            creator = false;

        play.usersLiked.some(uid => uid.toString() === req.user._id) ?
            hasLiked = true :
            hasLiked = false;

        res.render('details', { play, creator, hasLiked });
    } catch (error) {
        console.log(error);
    }
});

router.get('/theater/like/:playId', authenticated, async (req, res) => {
    const playId = req.params.playId;
    const userId = req.user._id;

    try {
        await theaterService.like(playId, userId);

        res.redirect(`/theater/details/${playId}`);
    } catch (error) {
        console.log(error);
    }
});

router.get('/theater/edit/:playId', authenticated, async (req, res) => {
    try {
        const play = await theaterService.getOne(req.params.playId);

        const { error } = req.session;

        error ?
            res.render('edit', { play, error }) :
            res.render('edit', { play });
    } catch (error) {
        console.log(error);
    }
});

router.post('/theater/edit/:playId', authenticated, async (req, res) => {
    const playId = req.params.playId;

    try {
        await theaterService.update(playId, req.body);

        res.redirect(`/theater/details/${playId}`);
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        req.session.error = error;

        res.redirect(`/theater/edit/${playId}`);
    }
});

router.get('/theater/delete/:playId', authenticated, async (req, res) => {
    try {
        await theaterService.remove(req.params.playId);

        res.redirect('/');
    } catch (error) {
        console.log(error);
    }
});

router.get('/theater/sort/date', authenticated, async (req, res) => {
    try {
        const sortedPlays = await theaterService.sortBy({ createdAt: -1 });

        res.render('user-home', { plays: sortedPlays });
    } catch (error) {
        console.log(error);
    }
});

router.get('/theater/sort/likes', authenticated, async (req, res) => {
    try {
        const sortedPlays = await theaterService.sortBy({ usersLiked: -1 });

        res.render('user-home', { plays: sortedPlays });
    } catch (error) {
        console.log(error);
    }
});

module.exports = router;