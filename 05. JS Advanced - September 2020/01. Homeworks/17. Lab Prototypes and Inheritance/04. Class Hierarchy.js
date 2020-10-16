function solve() {

    class Figure {

        constructor(units) {
            this.units = units;
        }

        changeUnits(unitType) {
            switch (unitType) {
                case 'm': this.units = 'm';
                    break;
                case 'cm': this.units = 'cm';
                    break;
                case 'mm': this.units = 'mm';
            }
        };
    }

    class Circle extends Figure {

        constructor(radius, units = 'cm') {
            super(units);
            this.radius = radius;
        }

        get area() {
            let currentRadius = this.radius;

            currentRadius = convertUnits(this.units, currentRadius);

            return Math.PI * currentRadius ** 2;
        }

        toString() {
            let currentRadius = this.radius;

            currentRadius = convertUnits(this.units, currentRadius);

            return `Figures units: ${this.units} Area: ${this.area} - radius: ${currentRadius}`;
        }
    }

    class Rectangle extends Figure {

        constructor(width, height, units = 'cm') {
            super(units);
            this.width = width;
            this.height = height;
        }

        get area() {
            let currWidth = this.width;
            let currHeight = this.height;

            currWidth = convertUnits(this.units, currWidth);
            currHeight = convertUnits(this.units, currHeight);

            return currWidth * currHeight;
        }

        toString() {
            let currWidth = this.width;
            let currHeight = this.height;

            currWidth = convertUnits(this.units, currWidth);
            currHeight = convertUnits(this.units, currHeight);

            return `Figures units: ${this.units} Area: ${this.area} - width: ${currWidth}, height: ${currHeight}`;
        }
    }

    function convertUnits(units, value) {
        if (units == 'mm') {
            value *= 10;
        } 
        if (this.units == 'm') {
            value /= 100;
        } 
        return value;
    }

    return {
        Figure,
        Circle,
        Rectangle,
    }
}