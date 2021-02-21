// TODO: Necessary changes
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SALT_ROUNDS, SECRET } = require('../config/init');
// const { isAlphanumeric, isEmail, isLength } = require('../helpers/validators');

const User = require('../models/User');

const register = async (data) => {
    //Data from req.body
    const { username, password, rePassword } = data;

    //Username validations
    const usernameExists = await User.exists({ username });
    if (usernameExists) throw { message: 'Username already exists!' };

    //Password validations
    if (password !== rePassword) throw { message: 'Both passwords should be the same...' };

    const hash = await bcrypt.hash(password, SALT_ROUNDS);
    const user = new User({ username, password: hash });

    await user.save();
}

const login = async (data) => {
    //Data from req.body
    const { username, password } = data;

    //Username validations
    const user = await User.findOne({ username });
    if (!user) throw { message: 'Invalid username!' };

    //Password validations
    const isValidPassword = await bcrypt.compare(password, user.password);
    if (!isValidPassword) throw { message: 'Invalid password!' };

    const token = jwt.sign({ _id: user._id, username }, SECRET, { expiresIn: '1h' });

    return token;
}

module.exports = {
    register,
    login,
}