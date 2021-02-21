const Play = require('../models/Play');
const User = require('../models/User');

const getAllAuth = async () => {
    return await Play.find({ isPublic: true }).sort({ createdAt: -1 }).lean();
}

const getAllGuest = async () => {
    return await Play.find({ isPublic: true }).sort({ usersLiked: -1 }).limit(3).lean();
}

const getOne = async (playId) => {
    return await Play.findById(playId).lean();
};

const create = async (data) => {
    let { isPublic } = data;

    isPublic ? data.isPublic = true : data.isPublic = false;

    const play = new Play(data);
    await play.save();
}

const like = async (playId, userId) => {
    const play = await Play.findById(playId);
    const user = await User.findById(userId);

    play.usersLiked.push(user);
    user.likedPlays.push(play);

    await play.save();
    await user.save();
}

const update = async (playId, data) => {
    let { isPublic } = data;

    isPublic ? data.isPublic = true : data.isPublic = false;

    await Play.findByIdAndUpdate(playId, data, { runValidators: true });
}

const remove = async (playId) => {
    await Play.findByIdAndRemove(playId);
}

const sortBy = async (sortOption) => {
    return await Play.find({ isPublic: true }).sort(sortOption).lean();
}

module.exports = {
    getAllAuth,
    getAllGuest,
    getOne,
    create,
    like,
    remove,
    update,
    sortBy,
}