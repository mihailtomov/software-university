function solveClasses() {

    class Hall {
        events = [];

        constructor(capacity, name) {
            this.capacity = capacity;
            this.name = name;
        }

        hallEvent(title) {
            this.validateTitle(title);

            this.events.push(title);

            return 'Event is added.';
        }

        close() {
            this.events = [];

            return `${this.name} hall is closed.`;
        }

        toString() {
            let output = `${this.name} hall - ${this.capacity}`;

            if (this.events.length > 0) {
                output += `\nEvents: ${this.events.join(', ')}`;
            }

            return output;
        }

        validateTitle(title) {
            if (this.events.some(e => e == title)) {
                throw new Error('This event is already added!');
            }
        }
    }

    class MovieTheater extends Hall {
        constructor(capacity, name, screenSize) {
            super(capacity, name);
            this.screenSize = screenSize;
        }

        close() {
            return super.close() + 'Аll screenings are over.';
        }

        toString() {
            let output = super.toString();

            output += '\n';
            output += `${this.name} is a movie theater with ${this.screenSize} screensize and ${this.capacity} seats capacity.`;

            return output;
        }
    }

    class ConcertHall extends Hall {
        constructor(capacity, name) {
            super(capacity, name);
        }

        hallEvent(title, performers) {
            let output = super.hallEvent(title);

            this.performers = performers;

            return output;
        }

        close() {
            return super.close() + 'Аll performances are over.';
        }

        toString() {
            let output = super.toString();

            if (this.events.length > 0) {
                output += `\n`;
                output += `Performers: ${this.performers.join(', ')}.`;
            }     
            
            return output;
        }
    }

    return {
        Hall,
        MovieTheater,
        ConcertHall,
    }
}

let classes = solveClasses();

let hall = new classes.Hall(20, 'Main');
console.log(hall.hallEvent('Breakfast Ideas'));
console.log(hall.hallEvent('Annual Charity Ball'));
console.log(hall.toString());
console.log(hall.close()); 

let movieHall = new classes.MovieTheater(10, 'Europe', '10m');
console.log(movieHall.hallEvent('Top Gun: Maverick'));
console.log(movieHall.toString());

let concert = new classes.ConcertHall(5000, 'Diamond');        
console.log(concert.hallEvent('The Chromatica Ball', ['LADY GAGA']));  
console.log(concert.toString());
console.log(concert.close());
console.log(concert.toString());

