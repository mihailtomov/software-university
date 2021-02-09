const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { SALT_ROUNDS, SECRET } = require('../config/init');

const User = require('../models/User');

const register = async (data) => {
    const { email, username, password, rePassword } = data;

    const emailExists = await User.exists({ email });
    if (emailExists) throw { message: 'Email already exists!' };

    const usernameExists = await User.exists({ username });
    if (usernameExists) throw { message: 'Username already exists!' };

    if (password !== rePassword) {
        throw { message: 'Password mismatch!' };
    }

    const hash = await bcrypt.hash(password, SALT_ROUNDS);

    const user = new User({ email, username, password: hash });

    const registeredUser = await user.save();

    const token = jwt.sign({ _id: registeredUser._id, username: registeredUser.username }, SECRET, { expiresIn: '1h' });

    return token;
}

const login = async (data) => {
    const { username, password } = data;

    const user = await User.findOne({ username });
    if (!user) throw { message: 'Invalid username!' };

    const isValidPassword = await bcrypt.compare(password, user.password);
    if (!isValidPassword) throw { message: 'Invalid password!' };

    const token = jwt.sign({ _id: user._id, username }, SECRET, { expiresIn: '1h' });

    return token;
}

module.exports = {
    register,
    login,
}