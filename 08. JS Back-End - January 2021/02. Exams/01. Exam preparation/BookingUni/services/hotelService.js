const Hotel = require('../models/Hotel');

const getAll = async () => {
    return await Hotel.find().lean();
}

const getOne = async (id) => {
    return await Hotel.findById(id).lean();
}

const create = async (data) => {
    data.freeRooms = Number(data.freeRooms);
    // validate data
    const hotel = new Hotel(data);

    return await hotel.save();
}

module.exports = {
    getAll,
    getOne,
    create,
}