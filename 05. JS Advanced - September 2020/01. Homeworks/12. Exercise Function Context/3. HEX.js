class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return '0x' + this.value.toString(16).toUpperCase();
    }

    plus(number) {
        let newHexObj = new Hex(this.value);

        if (number.value) {
            newHexObj.value += number.value;
        } else {
            newHexObj.value += number;
        }

        return newHexObj;
    }

    minus(number) {
        let newHexObj = new Hex(this.value);

        if (number.value) {
            newHexObj.value -= number.value;
        } else {
            newHexObj.value -= number;
        }
        
        return newHexObj;
    }

    parse(string) {
        return parseInt(string, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(a.parse(a.minus(9).toString()));