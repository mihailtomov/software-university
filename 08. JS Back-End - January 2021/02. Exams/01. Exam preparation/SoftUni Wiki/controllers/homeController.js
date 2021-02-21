const router = require('express').Router();
const articleService = require('../services/articleService');

router.get('/', async (req, res, next) => {
    try {
        let articles = await articleService.getTop3Articles();

        articles = articles.map(function (a) {
            a.description = a.description.split(' ').slice(0, 50).join(' ');

            return a;
        });

        res.render('topArticles', { articles });
    } catch (error) {
        next(error);
    }
});

module.exports = router;