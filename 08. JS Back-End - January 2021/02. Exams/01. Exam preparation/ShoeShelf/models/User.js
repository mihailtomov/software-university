const mongoose = require('mongoose');

const userSchema = mongoose.Schema({
    email: {
        type: String,
        required: true,
        unique: true,
    },
    fullName: {
        type: String,
    },
    password: {
        type: String,
        required: true,
    },
    offersBought: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Shoe',
    }],
});

const User = mongoose.model('User', userSchema);

module.exports = User;