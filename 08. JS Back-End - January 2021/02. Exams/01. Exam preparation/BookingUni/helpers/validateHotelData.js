const { isLength, isEmpty, isValidProtocol, isNumberLength } = require('./validators');

module.exports = (data) => {
    const { name, city, freeRooms, imageUrl } = data;

    //Name validation
    if (isEmpty(name)) throw { message: 'Name cannot be empty' };
    if (!isLength(name, 4)) throw { message: 'Name should be at least 4 chars long' };

    //City validation
    if (isEmpty(city)) throw { message: 'City cannot be empty', name };
    if (!isLength(city, 3)) throw { message: 'City should be at least 3 chars long', name };

    //Free rooms validation
    if (isEmpty(freeRooms)) throw { message: 'Free rooms cannot be empty', name, city };
    if (!isNumberLength(Number(freeRooms), 1, 100)) throw { message: 'Free rooms should be between 1 and 100', name, city };

    //Image url validation
    if (isEmpty(imageUrl)) throw { message: 'Image URL cannot be empty', name, city, freeRooms };
    if (!isValidProtocol(imageUrl)) throw { message: 'Image should start with http or https', name, city, freeRooms };
}