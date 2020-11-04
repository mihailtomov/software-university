const {assert} = require('chai');
const {isOddOrEven} = require('./isOddOrEven.js');

describe('isOddOrEven function tests', () => {
    it('Should return undefined if param type is not a string', () => {
        assert.equal(isOddOrEven(2), undefined);
    });

    it('Should return even if the string param has even length', () => {
        assert.equal(isOddOrEven('test'), 'even');
    });

    it('Should return odd if the string param has odd length', () => {
        assert.equal(isOddOrEven('tests'), 'odd');
    });
});