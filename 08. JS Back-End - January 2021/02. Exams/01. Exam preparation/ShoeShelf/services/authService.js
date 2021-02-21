// TODO: Necessary changes
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SALT_ROUNDS, SECRET } = require('../config/init');
const { isAlphanumeric, isLength } = require('../helpers/validators');

const User = require('../models/User');

const register = async (data) => {
    //Data from req.body
    const { email, fullName, password, rePassword } = data;

    //Email validations
    if (!isLength(email, 3)) throw { message: 'Email should be at least 3 characters long' };
    if (!isAlphanumeric(email.split('@')[0])) throw { message: 'Email should consist of english letters and numbers only!' };

    const emailExists = await User.exists({ email });
    if (emailExists) throw { message: 'Email already exists!' };

    //Password validations
    if (!isLength(password, 3)) throw { message: 'Password should be at least 3 characters long', email, fullName };
    if (!isAlphanumeric(password)) throw { message: 'Password should consist of english letters and numbers only!', email, fullName };

    if (password !== rePassword) throw { message: 'Password mismatch!', email, fullName };

    const hash = await bcrypt.hash(password, SALT_ROUNDS);
    const user = new User({ email, fullName, password: hash });

    await user.save();
}

const login = async (data) => {
    //Data from req.body
    const { email, password } = data;

    //Username validations
    const user = await User.findOne({ email });
    if (!user) throw { message: 'Invalid email!' };

    //Password validations
    const isValidPassword = await bcrypt.compare(password, user.password);
    if (!isValidPassword) throw { message: 'Invalid password!', email };

    const token = jwt.sign({ _id: user._id, email }, SECRET, { expiresIn: '1h' });

    return token;
}

module.exports = {
    register,
    login,
}