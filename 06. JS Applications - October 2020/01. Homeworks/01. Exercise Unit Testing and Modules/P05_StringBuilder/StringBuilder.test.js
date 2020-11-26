const { assert } = require('chai');
const StringBuilder = require('./string-builder.js');

describe('StringBuilder class tests', () => {
    let sb;

    beforeEach(() => {
        sb = new StringBuilder('test');
    });

    describe('constructor', () => {
        it('Should throw an error with the specified message if the param is not a string', () => {
            assert.throw(() => sb = new StringBuilder(5), 'Argument must be string');
        });

        it('Should set the string param to the internal array if the string is valid', () => {
            assert.equal(sb.toString(), 'test');
        });

        it('Should create empty array with undefined param', () => {
            sb = new StringBuilder(undefined);

            assert.equal(sb.toString(), '');
        });

        it('Should create empty array with empty string param', () => {
            sb = new StringBuilder('');

            assert.equal(sb.toString(), '');
        });
    });

    describe('append', () => {
        it('Should throw an error with the specified message if the param is not a string', () => {
            assert.throw(() => sb.append(5), 'Argument must be string');
        });

        it('Should append string param at the end of the internal array', () => {
            sb.append('word');

            assert.equal(sb.toString(), 'testword');
        });

        it('Should not append anything if the string param is empty string', () => {
            sb.append('');

            assert.equal(sb.toString(), 'test');
        });
    });

    describe('prepend', () => {
        it('Should throw an error with the specified message if the param is not a string', () => {
            assert.throw(() => sb.prepend(5), 'Argument must be string');
        });

        it('Should prepend string param at the beginning of the internal array', () => {
            sb.prepend('word');

            assert.equal(sb.toString(), 'wordtest');
        });

        it('Should not prepend anything if the string param is empty string', () => {
            sb.prepend('');

            assert.equal(sb.toString(), 'test');
        });
    });

    describe('insertAt', () => {
        it('Should throw an error with the specified message if the param is not a string', () => {
            assert.throw(() => sb.insertAt(5, 5), 'Argument must be string');
        });

        it('Should insert string param at the given index in the internal array', () => {
            sb.insertAt('d', 2);

            assert.equal(sb.toString(), 'tedst');
        });

        it('Should not insert anything if the string param is empty string', () => {
            sb.insertAt('', 2);

            assert.equal(sb.toString(), 'test');
        });
    });

    describe('remove', () => {
        it('Should not remove anything from the internal array if the length is a negative number', () => {
            sb.remove(1, -1);

            assert.equal(sb.toString(), 'test');
        });

        it('Should not remove anything from the internal array if the length is zero', () => {
            sb.remove(1, 0);

            assert.equal(sb.toString(), 'test');
        });

        it('Should remove length number of elements starting from the given index(included)', () => {
            sb.remove(1, 2);

            assert.equal(sb.toString(), 'tt');
        });

        it('Should remove all the elements until the end starting from the given index(included) if the given length is larger than the length of the internal array', () => {
            sb.remove(1, 5);

            assert.equal(sb.toString(), 't');
        });

        it('Should remove all the elements until the end starting from the given index(included) if the given length is equal to the length of the internal array', () => {
            sb.remove(1, 4);

            assert.equal(sb.toString(), 't');
        });
    });

    describe('toString', () => {
        it('Should return empty string if the internal array is empty', () => {
            sb.remove(0, 4);

            assert.equal(sb.toString(), '');
        });

        it('Should return the internal array as a string', () => {
            assert.equal(sb.toString(), 'test');
        });
    });
});