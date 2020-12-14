class Vacation {
    constructor(organizer, destination, budget) {
        this.organizer = organizer;
        this.destination = destination;
        this.budget = budget;
        this.kids = {};
    }

    registerChild(name, grade, budget) {
        if (budget < this.budget) {
            return `${name}'s money is not enough to go on vacation to ${this.destination}.`;
        }

        if (!this.kids[grade]) {
            this.kids[grade] = [];
        } 

        if (this.kids[grade].includes(`${name}-${budget}`)) {
            return `${name} is already in the list for this ${this.destination} vacation.`;
        } else {
            this.kids[grade].push(`${name}-${budget}`);
            return this.kids[grade];
        }
    }

    removeChild(name, grade) {
        if (!this.kids[grade]) {
            return `We couldn't find ${name} in ${grade} grade.`;
        } else if (this.kids[grade] && this.kids[grade].some(k => k.includes(name))){
            let kid = this.kids[grade].find(k => k.includes(name));
            let index = this.kids[grade].indexOf(kid);
            this.kids[grade].splice(index, 1);
            return this.kids[grade];
        }
    }

    toString() {
        Object.keys(this.kids).sort((a, b) => a - b);

        if (Object.values(this.kids).length == 0) {
            return `No children are enrolled for the trip and the organization of ${this.organizer} falls out...`;
        } else {
            let output = `${this.organizer} will take ${this.numberOfChildren()} children on trip to ${this.destination}\n`;

            Object.entries(this.kids).forEach(([grade, kids]) => {
                output += `Grade: ${grade}\n`;
                let currentKidNumber = 1;

                if (kids.length > 0) {
                    kids.forEach(kid => {
                        output += `${currentKidNumber}. ${kid}\n`;
                        currentKidNumber++;
                    })
                }
            })

            return output.trimEnd();
        }
    }

    numberOfChildren() {
        let numberOfChildren = 0;

        Object.values(this.kids).forEach(kidsArr => {
            numberOfChildren += kidsArr.length;
        });

        return numberOfChildren;
    }
}

let vacation = new Vacation('Miss Elizabeth', 'Dubai', 2000);
vacation.registerChild('Gosho', 5, 3000);
vacation.registerChild('Lilly', 6, 1500);
vacation.registerChild('Pesho', 7, 4000);
vacation.registerChild('Tanya', 5, 5000);
vacation.registerChild('Mitko', 10, 5500)
console.log(vacation.toString());



