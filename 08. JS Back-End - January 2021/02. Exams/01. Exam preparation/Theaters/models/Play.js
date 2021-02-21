const mongoose = require('mongoose');

const playSchema = mongoose.Schema({
    title: {
        type: String,
        required: [true, 'Title cannot be empty!'],
        trim: true,
        unique: true,
    },
    description: {
        type: String,
        required: [true, 'Description cannot be empty!'],
        trim: true,
        maxLength: 50,
    },
    imageUrl: {
        type: String,
        required: [true, 'Image URL cannot be empty!'],
        trim: true,
    },
    isPublic: {
        type: Boolean,
        default: false,
    },
    createdAt: {
        type: Date,
        required: true,
    },
    creator: {
        type: String,
        required: true,
    },
    usersLiked: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'User',
    }],
});

const Play = mongoose.model('Play', playSchema);

module.exports = Play;