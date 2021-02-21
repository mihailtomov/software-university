const Shoe = require('../models/Shoe');
const User = require('../models/User');

const getAll = async () => {
    return await Shoe.find().sort({ buyers: -1 }).lean();
}

const getOne = async (shoeId) => {
    return await Shoe.findById(shoeId).lean();
}

const getOneWithBuyers = async (shoeId) => {
    return await Shoe.findById(shoeId).populate('buyers').lean();
}

const create = async (data) => {
    const shoe = new Shoe(data);

    await shoe.save();
};

const update = async (shoeId, data) => {
    await Shoe.findByIdAndUpdate(shoeId, data, { runValidators: true });
};

const buy = async (shoeId, userId) => {
    const shoe = await Shoe.findById(shoeId);
    const user = await User.findById(userId);

    shoe.buyers.push(userId);
    user.offersBought.push(shoeId);

    await shoe.save();
    await user.save();
};

const remove = async (shoeId) => {
    await Shoe.findByIdAndRemove(shoeId);
};

module.exports = {
    getAll,
    getOne,
    getOneWithBuyers,
    create,
    update,
    buy,
    remove,
}