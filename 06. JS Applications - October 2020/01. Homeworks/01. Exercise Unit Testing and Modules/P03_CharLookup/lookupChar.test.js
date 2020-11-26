const {assert} = require('chai');
const {lookupChar} = require('./charLookUp.js');

describe('lookupChar function tests', () => {
    it('Should return undefined if the first param is not a string', () => {
        assert.equal(lookupChar(2, 2), undefined);
    });

    it('Should return undefined if the second param is not an integer', () => {
        assert.equal(lookupChar('test', 2.5), undefined);
    });

    it('Should return message Incorrect index if the string length is less than or equal to the index', () => {
        assert.equal(lookupChar('test', 4), 'Incorrect index');
    });

    it('Should return message Incorrect index if the index is a negative number', () => {
        assert.equal(lookupChar('test', -1), 'Incorrect index');
    });

    it('Should return the char at the specified index if the index is valid', () => {
        assert.equal(lookupChar('test', 1), 'e');
    });
});