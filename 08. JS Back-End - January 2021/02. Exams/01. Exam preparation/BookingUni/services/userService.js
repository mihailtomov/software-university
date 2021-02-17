const User = require('../models/User');

const getProfileInfo = async (userId) => {
    return await User.findById(userId, 'email bookedHotels')
    .populate('bookedHotels', 'name')
    .lean();
}

module.exports = {
    getProfileInfo,
}