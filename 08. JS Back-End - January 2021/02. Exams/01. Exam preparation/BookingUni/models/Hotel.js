const mongoose = require('mongoose');

const hotelSchema = mongoose.Schema({
    name: {
        type: String,
        unique: true,
    },
    city: {
        type: String,
    },
    imageUrl: {
        type: String,
    },
    freeRooms: {
        type: Number,
    },
    bookedUsers: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'User',
    }],
    owner: {
        type: String,
        required: true,
    }
});

const Hotel = mongoose.model('Hotel', hotelSchema);

module.exports = Hotel;