const router = require('express').Router();
const { authenticated } = require('../middlewares/guards');
const extractError = require('../helpers/extractError');
const articleService = require('../services/articleService');

router.get('/all-articles', async (req, res, next) => {
    try {
        let articles = await articleService.getAllArticles();

        res.render('allArticles', { articles });
    } catch (error) {
        console.log(error);
        next(error);
    }
});

router.get('/create', authenticated, (req, res) => {
    res.render('create');
});

router.post('/create', authenticated, async (req, res) => {
    const userId = req.user._id;

    try {
        await articleService.create(req.body, userId);

        res.redirect('/');
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        res.render('create', { error });
    }
});

router.get('/details/:articleId', async (req, res, next) => {
    const id = req.params.articleId;

    try {
        const article = await articleService.getOne(id);

        let paragraphs = article.description.replace(/\r\n/g, '<br />').split('<br /><br />');
        let author;
        req.user ? author = article.articleAuthor.equals(req.user._id) : author = false;

        res.render('details', { article, paragraphs, author });
    } catch (error) {
        next(error);
    }
});

router.get('/edit/:articleId', authenticated, async (req, res, next) => {
    const id = req.params.articleId;

    try {
        const article = await articleService.getOne(id);

        const { error } = req.session;

        if (error) {
            res.render('edit', { article, error });
            req.session.destroy();
        } else {
            res.render('edit', { article });
        }

    } catch (error) {
        next(error);
    }
});

router.post('/edit/:articleId', authenticated, async (req, res, next) => {
    const id = req.params.articleId;

    try {
        const article = await articleService.update(id, req.body);

        res.redirect(`/article/details/${id}`);
    } catch (error) {
        if (error.errors) {
            error = extractError(error);
        }

        req.session.error = error;

        res.redirect(`/article/edit/${id}`);
    }
});

router.get('/delete/:articleId', authenticated, async (req, res, next) => {
    const id = req.params.articleId;

    try {
        const article = await articleService.getOne(id);

        if (article.articleAuthor.equals(req.user._id)) {
            await articleService.remove(id);
    
            res.redirect('/article/all-articles');
        } else {
            res.redirect('/');
        }
    } catch (error) {
        next(error);
    }
});

router.get('/search', async (req, res, next) => {
    const searchText = req.query.search;

    try {
        const searchResults = await articleService.getAllArticles(searchText);

        res.render('search', {searchResults, searchText});
    } catch (error) {
        next(error)
    }
});

module.exports = router;