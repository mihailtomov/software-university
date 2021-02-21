const mongoose = require('mongoose');

const shoeSchema = mongoose.Schema({
    name: {
        type: String,
        required: [true, 'Name cannot be empty!'],
        trim: true,
        unique: true,
    },
    price: {
        type: Number,
        required: [true, 'Price cannot be empty!'],
        trim: true,
        min: [0, 'Price cannot be less than zero!'],
    },
    imageUrl: {
        type: String,
        required: [true, 'Image URL cannot be empty!'],
        trim: true,
    },
    description: {
        type: String,
        required: [true, 'Description cannot be empty!'],
        trim: true,
    },
    brand: {
        type: String,
        required: [true, 'Brand cannot be empty!'],
        trim: true,
    },
    createdAt: {
        type: Date,
    },
    creator: {
        type: String,
        required: true,
    },
    buyers: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'User',
    }],
});

const Shoe = mongoose.model('Shoe', shoeSchema);

module.exports = Shoe;