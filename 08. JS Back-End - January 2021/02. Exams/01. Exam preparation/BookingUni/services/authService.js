const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SALT_ROUNDS, SECRET } = require('../config/init');
const { isAlphanumeric, isEmail, isLength, isEmpty } = require('../helpers/validators');

const User = require('../models/User');

const register = async (data) => {
    const { email, username, password, rePassword } = data;

    //Email validations
    if (isEmpty(email)) throw { message: 'Email cannot be empty!' };
    if (!isEmail(email)) throw { message: 'Invalid email' };
    if (!isAlphanumeric(email.split('@')[0])) throw { message: 'Email should consist of english letters and numbers only!' };
    const emailExists = await User.exists({ email });
    if (emailExists) throw { message: 'Email already exists!' };

    //Username validations
    if (isEmpty(username)) throw { message: 'Username cannot be empty!', email };
    const usernameExists = await User.exists({ username });
    if (usernameExists) throw { message: 'Username already exists!', email };

    //Password validations
    if (isEmpty(password)) throw { message: 'Password cannot be empty!', email, username };
    if (!isLength(password, 5)) throw { message: 'Password should be at least 5 chars long', email, username };
    if (!isAlphanumeric(password)) throw { message: 'Password should consist of english letters and numbers only!', email, username };
    if (password !== rePassword) throw { message: 'Password mismatch!', email, username };

    const hash = await bcrypt.hash(password, SALT_ROUNDS);
    const user = new User({ email, username, password: hash });

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