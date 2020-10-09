class Stringer {
    constructor(string, length) {
        this._innerString = string;
        this._innerLength = length;
    }

    get innerString() {
        return this._innerString;
    }

    get innerLength () {
        return this._innerLength;
    }

    set innerLength(value) {
        if (value < 0) {
            this._innerLength = 0;
        } else {
            this._innerLength = value;
        }
    }

    increase(length) {
        this.innerLength += length;
    }
    decrease(length) {
        this.innerLength -= length;
    }
    toString() {
        if (this._innerString.length > this._innerLength) {
            return this._innerString.substring(0, this._innerLength) + '...';
        } else if (this._innerLength != 0 && this._innerString.length <= this._innerLength) {
            return this._innerString;
        }
        return '...';
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test
