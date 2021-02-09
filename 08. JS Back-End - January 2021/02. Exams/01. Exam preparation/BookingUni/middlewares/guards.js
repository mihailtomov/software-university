const guest = (req, res, next) => {
    const token = req.cookies['AUTH'];

    if (token) {
        res.redirect('/');
        return;
    }
    
    next();
}

const authenticated = (req, res, next) => {
    const token = req.cookies['AUTH'];

    if (!token) {
        res.redirect('/');
        return;
    }
    
    next();
}

module.exports = {
    guest,
    authenticated,
}