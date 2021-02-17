const mongoose = require('mongoose');

const courseSchema = mongoose.Schema({
    title: {
        type: String,
        required: true,
        unique: true,
    },
    description: {
        type: String,
        required: true,
        maxLength: [50, 'Description cannot be more than 50 characters long!'],
    },
    imageUrl: {
        type: String,
        required: true,
    },
    duration: {
        type: String,
        required: [true, 'Duration field cannot be empty!'],
    },
    createdAt: {
        type: Date,
        required: true,
    },
    creator: {
        type: String,
        required: true,
    },
    usersEnrolled: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'User',
    }],
});

const Course = mongoose.model('Course', courseSchema);

module.exports = Course;