const Course = require('../models/Course');
const User = require('../models/User');
const { isLength, isValidProtocol } = require('../helpers/validators');

const getAllGuest = async () => {
    return await Course.find().sort({ usersEnrolled: -1 }).lean();
}

const getAllAuth = async (query = '') => {
    query = query.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');

    const searchPattern = new RegExp(query, 'i');

    return await Course.find({ title: { $regex: searchPattern } }).sort({ createdAt: 1 }).lean();
}

const getOne = async (courseId) => {
    return await Course.findById(courseId).lean();
}

const create = async (data) => {
    const { title, description, imageUrl, duration } = data;

    if (!isLength(title, 4)) throw { message: 'Title should be at least 4 characters long!' };
    if (!isLength(description, 20)) throw { message: 'Description should be at least 20 characters long!', title };
    if (!isValidProtocol(imageUrl)) throw { message: 'Image URL should start with http or https!', title, description };

    const course = new Course(data);

    await course.save();
}

const enroll = async (courseId, userId) => {
    const course = await Course.findById(courseId);
    const user = await User.findById(userId);

    course.usersEnrolled.push(user);
    user.enrolledCourses.push(course);

    await course.save();
    await user.save();
}

const update = async (data, courseId) => {
    const { title, description, imageUrl, duration } = data;

    if (!isLength(title, 4)) throw { message: 'Title should be at least 4 characters long!' };
    if (!isLength(description, 20)) throw { message: 'Description should be at least 20 characters long!' };
    if (!isValidProtocol(imageUrl)) throw { message: 'Image URL should start with http or https!' };

    await Course.findByIdAndUpdate(courseId, data, { runValidators: true });
}

const remove = async (courseId) => {
    await Course.findByIdAndDelete(courseId);
}

module.exports = {
    getAllGuest,
    getAllAuth,
    getOne,
    create,
    enroll,
    update,
    remove,
}