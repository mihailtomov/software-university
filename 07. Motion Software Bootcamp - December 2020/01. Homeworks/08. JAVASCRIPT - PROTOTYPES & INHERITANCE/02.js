function toStringExtension() {

    class Person {
        name;
        email;
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;
        }
    }

    class Teacher extends Person {
        subject;
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return super.toString().slice(0, super.toString().length - 1) + `, subject: ${this.subject})`;
        }
    }

    class Student extends Person {
        course;
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return super.toString().slice(0, super.toString().length - 1) + `, course: ${this.course})`;
        }
    }

    return {
        Person,
        Teacher,
        Student,
    }
}

let { Person, Teacher, Student } = toStringExtension();
let p = new Person("Peter", "peter@abv.bg");
console.log(p.toString());
let t = new Teacher("George", "george@abv.bg", "math");
console.log(t.toString());
let s = new Student("Teodor", "teodor@abv.bg", "JS Web");
console.log(s.toString());