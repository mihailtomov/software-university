const guest = (req, res, next) => {
    if (req.user) {
        res.redirect('/');
        return;
    }
    
    next();
}

const authenticated = (req, res, next) => {
    if (!req.user) {
        res.redirect('/');
        return;
    }
    
    next();
}

module.exports = {
    guest,
    authenticated,
}