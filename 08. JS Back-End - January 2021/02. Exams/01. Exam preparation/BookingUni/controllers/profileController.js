const router = require('express').Router();
const { authenticated } = require('../middlewares/guards');
const userService = require('../services/userService');

router.get('/', authenticated, async (req, res) => {
    try {
        const { email, bookedHotels } = await userService.getProfileInfo(req.user._id);

        const user = { username: req.user.username, email, bookedHotels };

        res.render('profile', { user });
    } catch (error) {
        console.log(error);
    }
});


module.exports = router;