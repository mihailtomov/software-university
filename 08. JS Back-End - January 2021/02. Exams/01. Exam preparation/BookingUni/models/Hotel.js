const mongoose = require('mongoose');

const hotelSchema = mongoose.Schema({
    name: {
        type: String,
        required: true,
        unique: true,
    },
    city: {
        type: String,
        required: true,
    },
    imageUrl: {
        type: String,
        required: true,
    },
    freeRooms: {
        type: Number,
        required: true,
        min: 1,
        max: 100,
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