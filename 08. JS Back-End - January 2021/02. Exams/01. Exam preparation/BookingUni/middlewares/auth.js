const jwt = require('jsonwebtoken');
const { SECRET } = require('../config/init');

const auth = () => {
    return function (req, res, next) {
        const token = req.cookies['AUTH'];

        if (token) {
            jwt.verify(token, SECRET, (err, decodedToken) => {
                if (err) {
                    res.clearCookie('AUTH');
                } else {
                    req.user = decodedToken;
                    res.locals.isAuthenticated = true;
                    res.locals.name = decodedToken.username;
                }
            });
        }

        next();
    }
}

module.exports = auth;