const mongoose = require('mongoose');

const expenseSchema = mongoose.Schema({
    merchant: {
        type: String,
        required: true,
    },
    total: {
        type: Number,
        required: true,
    },
    category: {
        type: String,
        required: true,
    },
    description: {
        type: String,
        required: true,
        minLength: [3, 'Description should be between 3 and 30 characters long!'],
        maxLength: [30, 'Description should be between 3 and 30 characters long!'],
    },
    report: {
        type: Boolean,
        required: true,
        default: false,
    },
    creator: {
        type: mongoose.Types.ObjectId,
        ref: 'User',
        required: true,
    },
});

const Expense = mongoose.model('Expense', expenseSchema);

module.exports = Expense;