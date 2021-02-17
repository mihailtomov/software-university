const Hotel = require('../models/Hotel');
const User = require('../models/User');
const validateHotelData = require('../helpers/validateHotelData');

const getAll = async () => {
    return await Hotel.find().sort({ freeRooms: -1 }).lean();
}

const getOne = async (id) => {
    return await Hotel.findById(id).lean();
}

const create = async (data, userId) => {
    validateHotelData(data);

    data.freeRooms = Number(data.freeRooms);

    const hotel = new Hotel(data);
    const offeredHotel = await hotel.save();

    const user = await User.findById(userId);
    user.offeredHotels.push(offeredHotel);

    await user.save();
}

const book = async (hotelId, userId) => {
    const hotel = await Hotel.findById(hotelId);
    const user = await User.findById(userId);

    hotel.bookedUsers.push(user);
    user.bookedHotels.push(hotel);

    await hotel.save();
    await user.save();
}

const update = async (hotelId, data) => {
    validateHotelData(data);
    
    await Hotel.findByIdAndUpdate(hotelId, data);
}

const deleteOne = async (hotelId) => {
    await Hotel.findByIdAndRemove(hotelId);
}

module.exports = {
    getAll,
    getOne,
    create,
    book,
    update,
    deleteOne,
}