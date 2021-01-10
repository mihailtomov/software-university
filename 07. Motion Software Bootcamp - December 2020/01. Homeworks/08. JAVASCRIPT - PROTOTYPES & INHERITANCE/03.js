function extendClass(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function() {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}

class Test {
    toString(){
        return `Coming from the Test Class!!!`;
    }
}

extendClass(Test);

let t = new Test();
console.log(t.toSpeciesString());