const mongoose = require('mongoose');

const articleSchema = mongoose.Schema({
    title: {
        type: String,
        required: [true, 'Article title cannot be empty!'],
        trim: true,
        unique: true,
        minLength: [5, 'Article title should be at least 5 characters long...'],
    },
    description: {
        type: String,
        required: [true, 'Article description cannot be empty!'],
        trim: true,
        minLength: [20, 'Article description should be at least 20 characters long...'],
    },
    articleAuthor: {
        type: mongoose.Types.ObjectId,
    },
    editors: [{
        type: mongoose.Schema.Types.ObjectId,
        ref: 'User',
    }],
    creationDate: {
        type: Date,
        default: Date.now(),
    },
});

const Article = mongoose.model('Article', articleSchema);

module.exports = Article;