const mongoose = require('mongoose');

const userSchema = mongoose.Schema({
    email: {
        type: String,
        required: true,
        unique: true,
    },
    username: {
        type: String,
        required: true,
        unique: true,
    },
    password: {
        type: String,
        required: true,
    },
    bookedHotels: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Hotel',
    }],
    offeredHotels: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Hotel',
    }]
});

const User = mongoose.model('User', userSchema);

module.exports = User;