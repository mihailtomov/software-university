const Article = require('../models/Article');
const User = require('../models/User');

const getAllArticles = async (query = '') => {
    return await Article.find({ title: { $regex: query, $options: 'i' } }).lean();
}

const getTop3Articles = async () => {
    return await Article.find().limit(3).lean();
}

const getOne = async (id) => {
    return await Article.findById(id).lean();
}

const create = async (data, userId) => {
    data.articleAuthor = userId;

    const user = await User.findById(userId);
    const article = new Article(data);

    user.createdArticles.push(article);

    await user.save();
    await article.save();
};

const update = async (id, data) => {
    await Article.findByIdAndUpdate(id, data, { runValidators: true });
};

const remove = async (id) => {
    await Article.findByIdAndRemove(id);
};

module.exports = {
    getAllArticles,
    getTop3Articles,
    getOne,
    create,
    update,
    remove,
}