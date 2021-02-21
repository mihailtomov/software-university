// TODO: Necessary changes
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SALT_ROUNDS, SECRET } = require('../config/init');
const { isAlphanumeric, isLength } = require('../helpers/validators');

const User = require('../models/User');

const register = async (data) => {
    //Data from req.body
    const { username, password, rePassword, amount } = data;

    //Username validations
    if (!isLength(username, 4)) throw { message: 'Username should be at least 4 characters long and should consist of english letters and numbers only!' };
    if (!isAlphanumeric(username)) throw { message: 'Username should be at least 4 characters long and should consist of english letters and numbers only!' };
    const usernameExists = await User.exists({ username });
    if (usernameExists) throw { message: 'Username already exists!' };

    //Password validations
    if (!isLength(password, 4)) throw { message: 'Password should be at least 4 characters long!', username };
    if (password !== rePassword) throw { message: 'The repeat password should be equal to the password!', username };

    //Amount validations
    if (Number(amount) < 0) throw { message: 'The account amount should be a positive number!', username, password, rePassword };

    const hash = await bcrypt.hash(password, SALT_ROUNDS);
    const user = new User({ username, password: hash, amount: Number(amount) });

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
    if (!isValidPassword) throw { message: 'Invalid password!', username };

    const token = jwt.sign({ _id: user._id, username }, SECRET, { expiresIn: '1h' });

    return token;
}

module.exports = {
    register,
    login,
}