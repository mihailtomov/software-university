const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SALT_ROUNDS, SECRET } = require('../config/init');
const { isAlphanumeric, isLength } = require('../helpers/validators');

const User = require('../models/User');

const register = async (data) => {
    const { username, password, rePassword } = data;

    //Username validations
    if (!isLength(username, 3)) throw { message: 'Username should be at least 3 characters long!' };
    if (!isAlphanumeric(username)) throw { message: 'Username should consist of english letters and numbers only!' };
    const usernameExists = await User.exists({ username });
    if (usernameExists) throw { message: 'Username already exists!' };

    //Password validations
    if (!isLength(password, 3)) throw { message: 'Password should be at least 3 characters long!', username };
    if (!isAlphanumeric(password)) throw { message: 'Password should consist of english letters and numbers only!', username };

    if (password !== rePassword) throw { message: 'Password mismatch!', username };

    const hash = await bcrypt.hash(password, SALT_ROUNDS);
    const user = new User({ username, password: hash });

    await user.save();
}

const login = async (data) => {
    const { username, password } = data;

    //Username validations
    const user = await User.findOne({ username });
    if (!user) throw { message: 'Invalid username!' };

    //Password validations
    const isValidPassword = await bcrypt.compare(password, user.password);
    if (!isValidPassword) throw { message: 'Invalid password!', username };

    const token = jwt.sign({ _id: user._id, username }, SECRET, { expiresIn: '1h' });

    return token;
}

module.exports = {
    register,
    login,
}