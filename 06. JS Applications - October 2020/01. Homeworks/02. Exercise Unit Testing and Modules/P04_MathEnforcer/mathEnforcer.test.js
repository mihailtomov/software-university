const {assert, expect} = require('chai');
const {addFive, subtractTen, sum} = require('./mathEnforcer.js');

describe('mathEnforcer tests', () => {
    let notNums;

    beforeEach(() => {
        notNums = [null, undefined, {}, [], '', Symbol(), Boolean(), function() {}];
    });

    describe('addFive', () => {
        it('Should return undefined if the param is not a number', () => {
            notNums.forEach(arg => assert.equal(addFive(arg), undefined));
        });

        it('Should return the number plus five if the param is a positive integer', () => {
            assert.equal(addFive(5), 10);
        });

        it('Should return the number plus five if the param is a negative integer', () => {
            assert.equal(addFive(-5), 0);
        });

        it('Should return the number plus five with precision if the param is a floating-point number', () => {
            expect(addFive(1.23)).to.be.closeTo(6.23, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('Should return undefined if the param is not a number', () => {
            notNums.forEach(arg => assert.equal(subtractTen(arg), undefined));
        });

        it('Should return the number minus ten if the param is a positive integer', () => {
            assert.equal(subtractTen(15), 5);
        });

        it('Should return the number minus ten if the param is a negative integer', () => {
            assert.equal(subtractTen(-5), -15);
        });

        it('Should return the number minus ten with precision if the param is a floating-point number', () => {
            expect(subtractTen(11.23)).to.be.closeTo(1.23, 0.01);
        });
    });

    describe('sum', () => {
        it('Should return undefined if the first param is not a number', () => {
            notNums.forEach(arg => assert.equal(sum(arg, 2), undefined));
        });

        it('Should return undefined if the second param is not a number', () => {
            notNums.forEach(arg => assert.equal(sum(2, arg), undefined));
        });

        it('Should return the difference if one of the params is a negative integer', () => {
            assert.equal(sum(-5, 6), 1);
        });

        it('Should return the sum of the two numbers if both params are positive integers', () => {
            assert.equal(sum(3, 5), 8);
        });

        it('Should return the sum of the two numbers if both params are negative integers', () => {
            assert.equal(sum(-3, -5), -8);
        });

        it('Should return the sum of the two numbers with precision if one of the params is a floating-point number', () => {
            expect(sum(1.54, 2)).to.be.closeTo(3.54, 0.01);
        });

        it('Should return the sum of the two numbers with precision if both params are floating-point numbers', () => {
            expect(sum(1.54, 2.37)).to.be.closeTo(3.91, 0.01);
        });
    });
});