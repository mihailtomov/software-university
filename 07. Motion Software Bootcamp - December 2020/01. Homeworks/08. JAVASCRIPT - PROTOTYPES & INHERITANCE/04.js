// function solve() {

//     class Figure {
//         units = 'cm';

//         changeUnits(value) {
//             switch (value) {
//                 case 'mm':
//                     this.units = 'mm';
//                     break;
//                 case 'm':
//                     this.units = 'm';
//                     break;
//                 default:
//                     this.units = 'cm';
//                     break;
//             }
//         }

//         get area() { };

//         convertUnits(value) {
//             switch (this.units) {
//                 case 'mm': return value *= 10;
//                 case 'm': return value /= 100;
//                 case 'cm': return value;
//             }
//         }

//         toString() {
//             return `Figures units: ${this.units} Area: ${this.area}`;
//         }
//     }

//     class Circle extends Figure {
//         radius;

//         constructor(radius) {
//             super();
//             this.radius = radius;
//         }

//         get area() {
//             return Math.PI * this.convertUnits(this.radius) ** 2;
//         }

//         toString() {
//             return super.toString() + ` - radius: ${this.convertUnits(this.radius)}`;
//         }
//     }

//     class Rectangle extends Figure {
//         width;
//         height;

//         constructor(width, height, units) {
//             super();
//             this.width = width;
//             this.height = height;
//             this.units = units;
//         }

//         get area() {
//             return this.convertUnits(this.width) * this.convertUnits(this.height);
//         }

//         toString() {
//             return super.toString() + ` - width: ${this.convertUnits(this.width)}, height: ${this.convertUnits(this.height)}`;
//         }
//     }

//     return {
//         Figure,
//         Circle,
//         Rectangle,
//     }
// }

function Figure() {
    this.units = 'cm';

    Object.defineProperty(this, 'area', {
        configurable: true,
        get: function (){
            return NaN;
        }
    })

    return this;
}

Figure.prototype.changeUnits = function (value) {
    switch (value) {
        case 'mm':
            this.units = 'mm';
            break;
        case 'm':
            this.units = 'm';
            break;
        default:
            this.units = 'cm';
            break;
    }
}

Figure.prototype.convertUnits = function (value) {
    switch (this.units) {
        case 'mm': return value *= 10;
        case 'm': return value /= 100;
        case 'cm': return value;
    }
}

Figure.prototype.toString = function () {
    return `Figures units: ${this.units} Area: ${this.area}`;
}

const Circle = (function(_super){
    function Circle(radius) {
        _super.call(this);

        this.radius = radius;
    
        Object.defineProperty(this, 'area', {
            configurable: true,
            get: function() {
                return Math.PI * this.convertUnits(this.radius) ** 2;
            }
        })
    
        return this;
    }

    Object.assign(Circle.prototype, _super.prototype);

    Circle.prototype.toString = function() {
        return _super.prototype.toString.call(this) + ` - radius: ${this.convertUnits(this.radius)}`;
    }

    return Circle;

}(Figure))


            
const { Figure, Circle, Rectangle } = solve();

let c = new Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50