const router = require('express').Router();
const courseService = require('../services/courseService');
const extractError = require('../helpers/extractError');
const { authenticated } = require('../middlewares/guards');

router.get('/', async (req, res) => {
    const loggedIn = req.user;

    try {
        if (!loggedIn) {
            const courses = await courseService.getAllGuest();

            res.render('guest-home', { courses });
        } else {
            let courses = await courseService.getAllAuth(req.query.search);

            courses = courses.map(function (course) {
                const [dayOfWeek, month, day, , time] = course.createdAt.toString().split(' ');
                course.createdAt = dayOfWeek + ' ' + month + ' ' + day + ' ' + time;
                return course;
            });

            res.render('user-home', { courses });
        }
    } catch (error) {
        console.log(error);
    }
});

router.get('/course/create', authenticated, (req, res) => {
    res.render('create');
});

router.post('/course/create', authenticated, async (req, res) => {
    const { title, description, imageUrl } = req.body;

    try {
        await courseService.create({ ...req.body, createdAt: Date.now(), creator: req.user.username });

        res.redirect('/');
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
            Object.assign(error, { title, description, imageUrl });
        }
        res.render('create', { error });
    }
});

router.get('/course/details/:courseId', authenticated, async (req, res) => {
    try {
        const course = await courseService.getOne(req.params.courseId);

        let creator;

        course.creator === req.user.username ? creator = true : creator = false;
        let enrolled = course.usersEnrolled.some(uid => uid.toString() === req.user._id);

        res.render('details', { course, creator, enrolled });
    } catch (error) {
        console.log(error);
    }
});

router.get('/course/enroll/:courseId', authenticated, async (req, res) => {
    try {
        const courseId = req.params.courseId;
        const userId = req.user._id;

        await courseService.enroll(courseId, userId);

        res.redirect(`/course/details/${courseId}`);
    } catch (error) {
        console.log(error);
    }
});

router.get('/course/edit/:courseId', authenticated, async (req, res) => {
    try {
        const course = await courseService.getOne(req.params.courseId);

        const { error } = req.session;

        if (error) {
            res.render('edit', { course, error });
            req.session.destroy();
        } else {
            res.render('edit', { course });
        }
    } catch (error) {
        console.log(error);
    }
});

router.post('/course/edit/:courseId', authenticated, async (req, res) => {
    const courseId = req.params.courseId;

    try {
        await courseService.update(req.body, courseId);

        res.redirect(`/course/details/${courseId}`);
    } catch (error) {
        error.errors ? req.session.error = extractError(error) : req.session.error = error;

        res.redirect(`/course/edit/${courseId}`);
    }
});

router.get('/course/delete/:courseId', authenticated, async (req, res) => {
    try {
        await courseService.remove(req.params.courseId);

        res.redirect('/');
    } catch (error) {
        console.log(error);
    }
});

module.exports = router;