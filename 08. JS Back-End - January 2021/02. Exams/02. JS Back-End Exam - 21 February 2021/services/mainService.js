// TODO: Replace ModelName and apply necessary logic!!!

const ModelName = require('../models/ModelName');
const User = require('../models/User');

const getAll = async () => {
    return await ModelName.find().lean();
}

const getOne = async (id) => {
    return await ModelName.findById(id).lean();
}

const getOneWithPopulatedProperty = async (id) => {
    return await ModelName.findById(id).populate('propName').lean();
}

const create = async (data) => {
    const modelName = new ModelName(data);

    await modelName.save();
};

const update = async (id, data) => {
    await ModelName.findByIdAndUpdate(id, data, { runValidators: true });
};

const buy = async (id, userId) => {
    const modelName = await ModelName.findById(id);
    const user = await User.findById(userId);

    modelName.buyers.push(userId);
    user.offersBought.push(id);

    await modelName.save();
    await user.save();
};

const remove = async (id) => {
    await ModelName.findByIdAndRemove(id);
};

module.exports = {
    getAll,
    getOne,
    getOneWithPopulatedProperty,
    create,
    update,
    buy,
    remove,
}