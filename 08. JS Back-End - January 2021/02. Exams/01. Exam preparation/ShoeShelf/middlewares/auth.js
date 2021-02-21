const jwt = require('jsonwebtoken');
const { SECRET, AUTH_COOKIE } = require('../config/init');

const auth = () => {
    return function (req, res, next) {
        const token = req.cookies[AUTH_COOKIE];

        if (token) {
            jwt.verify(token, SECRET, (err, decodedToken) => {
                if (err) {
                    res.clearCookie(AUTH_COOKIE);
                } else {
                    req.user = decodedToken;
                    res.locals.isAuthenticated = true;
                    res.locals.email = decodedToken.email;
                }
            });
        }

        next();
    }
}

module.exports = auth;