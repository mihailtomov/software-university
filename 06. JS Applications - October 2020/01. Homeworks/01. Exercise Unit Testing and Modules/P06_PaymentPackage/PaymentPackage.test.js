const { assert } = require('chai');
const PaymentPackage = require('./PaymentPackage.js');

describe('PaymentPackage class tests', function () {
    let pp;

    beforeEach(() => {
        pp = new PaymentPackage('name', 1);
    });

    describe('constructor', () => {
        it('Should throw a name error if no arguments are passed', () => {
            assert.throw(() => pp = new PaymentPackage(), 'Name must be a non-empty string');
        });

        it('Should throw a name error if first param is not a string', () => {
            assert.throw(() => pp = new PaymentPackage(2, 1), 'Name must be a non-empty string');
        });

        it('Should throw a name error if first param is empty string', () => {
            assert.throw(() => pp = new PaymentPackage('', 1), 'Name must be a non-empty string');
        });

        it('Should throw a value error if second param is not a number', () => {
            assert.throw(() => pp = new PaymentPackage('test', 'string'), 'Value must be a non-negative number');
        });

        it('Should throw a value error if second param is a negative number', () => {
            assert.throw(() => pp = new PaymentPackage('test', -1), 'Value must be a non-negative number');
        });

        it('Should set and return the first param with correct arguments', () => {
            assert.equal(pp.name, 'name');
        });

        it('Should set and return the second param with correct arguments', () => {
            assert.equal(pp.value, 1);
        });

        it('Should set and return property VAT to default value with correct arguments', () => {
            assert.equal(pp.VAT, 20);
        });

        it('Should set and return property active to default value with correct arguments', () => {
            assert.equal(pp.active, true);
        });
    });

    describe('name', () => {
        it('Should throw a name error if the passed value is not a string', () => {
            assert.throw(() => pp.name = true, 'Name must be a non-empty string');
        });

        it('Should throw a name error if the passed value is empty string', () => {
            assert.throw(() => pp.name = '', 'Name must be a non-empty string');
        });

        it('Should set and return the value if the argument is valid', () => {
            pp.name = 'otherName';

            assert.equal(pp.name, 'otherName');
        });
    });

    describe('value', () => {
        it('Should throw a value error if the passed value is not a number', () => {
            assert.throw(() => pp.value = [], 'Value must be a non-negative number');
        });

        it('Should throw a value error if the passed value is a negative number', () => {
            assert.throw(() => pp.value = -1, 'Value must be a non-negative number');
        });

        it('Should set and return the value if the argument is valid', () => {
            pp.value = 5;

            assert.equal(pp.value, 5);
        });
    });

    describe('VAT', () => {
        it('Should throw a VAT error if the passed value is not a number', () => {
            assert.throw(() => pp.VAT = 'string', 'VAT must be a non-negative number');
        });

        it('Should throw a VAT error if the passed value is a negative number', () => {
            assert.throw(() => pp.VAT = -1, 'VAT must be a non-negative number');
        });

        it('Should set and return the value if the passed argument is valid', () => {
            pp.VAT = 30;

            assert.equal(pp.VAT, 30);
        });
    });

    describe('active', () => {
        it('Should throw an active error if the passed value is not a boolean', () => {
            assert.throw(() => pp.active = 'string', 'Active status must be a boolean');
        });

        it('Should set and return the value if the passed argument is valid', () => {
            pp.active = false;

            assert.equal(pp.active, false);
        });
    });

    describe('toString', () => {
        it('Should return information about the object in the correct format', () => {
            let expectedOutput = [];
            expectedOutput.push('Package: name');
            expectedOutput.push('- Value (excl. VAT): 1');
            expectedOutput.push('- Value (VAT 20%): 1.2');

            assert.equal(pp.toString(), expectedOutput.join('\n'));
        });
    });
});
