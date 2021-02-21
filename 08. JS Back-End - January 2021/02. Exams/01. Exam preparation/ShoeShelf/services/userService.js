const User = require('../models/User');

const getUserInfo = async (userId) => {
    return await User.findById(userId).populate('offersBought').lean();
}

module.exports = {
    getUserInfo,
}