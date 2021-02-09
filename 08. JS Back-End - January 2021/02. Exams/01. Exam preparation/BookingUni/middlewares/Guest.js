module.exports = (req, res, next) => {
    const token = req.cookies['AUTH'];

    if (token) {
        res.redirect('/');
        return;
    }
    
    next();
}