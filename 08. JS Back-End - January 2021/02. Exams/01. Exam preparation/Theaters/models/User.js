const mongoose = require('mongoose');

const userSchema = mongoose.Schema({
    username: {
        type: String,
        required: true,
        unique: true,
    },
    password: {
        type: String,
        required: true,
    },
    likedPlays: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Play',
    }],
});

const User = mongoose.model('User', userSchema);

module.exports = User;