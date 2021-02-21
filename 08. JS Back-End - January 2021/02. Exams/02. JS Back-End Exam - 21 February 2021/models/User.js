const mongoose = require('mongoose');

const userSchema = mongoose.Schema({
    username: {
        type: String,
        required: [true, 'Username cannot be empty!'],
        unique: true,
    },
    password: {
        type: String,
        required: [true, 'Password cannot be empty!'],
    },
    amount: {
        type: Number,
        required: [true, 'Amount cannot be empty!'],
        default: 0,
    },
    expenses: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'Expense',
    }],
});

const User = mongoose.model('User', userSchema);

module.exports = User;