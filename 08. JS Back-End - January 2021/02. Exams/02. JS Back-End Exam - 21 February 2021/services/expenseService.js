const Expense = require('../models/Expense');
const User = require('../models/User');

const getAllByUser = async (userId) => {
    return await Expense.find({ creator: userId }).lean();
}

const getOne = async (expenseId) => {
    return await Expense.findById(expenseId).lean();
}

const create = async (data, userId) => {
    data.total ? data.total = Number(data.total) : data.total = undefined;
    if (data.category && data.category.includes('-')) {
        data.category = data.category.split('-').map(c => c[0].toUpperCase() + c.slice(1)).join(' ');
    } else if (data.category && !data.category.includes('-')) {
        data.category = data.category[0].toUpperCase() + data.category.slice(1);
    }
    data.report == 'on' ? data.report = true : data.report = false;

    const expense = new Expense(data);
    const user = await User.findById(userId);
    user.expenses.push(expense);

    await user.save();
    await expense.save();
};

const refill = async (userId, data) => {
    data.amount = Number(data.amount);
    if (data.amount < 0) throw { message: 'The account amount should be a positive number!' };

    const user = await User.findById(userId);
    user.amount += data.amount;

    await user.save();
};

const remove = async (expenseId) => {
    await Expense.findByIdAndRemove(expenseId);
};

const getProfileInfo = async (userId) => {
    return await User.findById(userId).select('amount expenses').populate('expenses').lean();
}

module.exports = {
    getAllByUser,
    getOne,
    create,
    refill,
    getProfileInfo,
    remove,
}