const mongoose = require('mongoose');

const expenseSchema = mongoose.Schema({
    id: {
        
    },
    merchant: {
        type: String,
        required: [true, 'Merchant cannot be empty!'],
        minLength: [4, 'Merchant should be at least 4 characters long!'],
    },
    total: {
        type: Number,
        required: [true, 'Total cannot be empty!'],
        min: [0, 'Total should be a positive number!'],
    },
    category: {
        type: String,
        required: [true, 'Category cannot be empty!'],
    },
    description: {
        type: String,
        required: [true, 'Description cannot be empty!'],
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