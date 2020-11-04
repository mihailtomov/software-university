class Parking {
    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {
        if (this.vehicles.length == this.capacity) {
            throw new Error('Not enough parking space.');
        }

        this.vehicles.push({ carModel, carNumber, payed: false });

        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        if (!this.vehicles.some(c => c.carNumber == carNumber)) {
            throw new Error('The car, you\'re looking for, is not found.');
        }

        let car = this.vehicles.find(c => c.carNumber == carNumber);

        if (car.payed == false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }

        this.vehicles = this.vehicles.filter(c => c != car);

        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber) {
        if (!this.vehicles.some(c => c.carNumber == carNumber)) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        let car = this.vehicles.find(c => c.carNumber == carNumber);

        if (car.payed) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`;
    }

    getStatistics(...args) {
        if (args.length == 0) {
            let output = `The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.\n`;

            let sortedVehicles = this.vehicles.sort((a, b) => a.carModel.localeCompare(b.carModel));

            sortedVehicles.forEach(car => {
                let payedInfo = '';

                if (car.payed) {
                    payedInfo = 'payed';
                } else {
                    payedInfo = 'Not payed';
                }

                output += `${car.carModel} == ${car.carNumber} - ${payedInfo}\n`;
            });

            return output.trim();
        } else {
            let carNumber = args[0];

            let car = this.vehicles.find(c => c.carNumber == carNumber);

            let payedInfo = '';

            if (car.payed) {
                payedInfo = 'payed';
            } else {
                payedInfo = 'Not payed';
            }

            return `${car.carModel} == ${car.carNumber} - ${payedInfo}`;
        }
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));