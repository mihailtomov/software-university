function solveClasses() {

    class Person {
        problems = [];

        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        toString() {
            return `${this.firstName} ${this.lastName} is part of SoftUni community now!`;
        }
    }

    class Teacher extends Person {
        constructor(firstName, lastName) {
            super(firstName, lastName);
        }

        createProblem(id, difficulty) {
            this.problems.push({ id, difficulty });

            return this.problems;
        }

        getProblems() {
            return this.problems;
        }

        showProblemSolution(id) {
            if (!this.problems.some(p => p.id == id)) {
                throw new Error(`Problem with id ${id} not found.`);
            } else {
                let problem = this.problems.find(p => p.id == id);
                problem.difficulty -= 1;
                return problem;
            }
        }
    }

    class Student extends Person {
        constructor(firstName, lastName, graduationCredits, problems) {
            super(firstName, lastName);
            this.graduationCredits = graduationCredits;
            this.problems = problems;
            this.myCredits = 0;
            this.solvedProblems = [];
        }

        solveProblem(id) {
            if (!this.problems.some(p => p.id == id)) {
                throw new Error(`Problem with id ${id} not found.`);
            } else {
                let problem = this.problems.find(p => p.id == id);

                if (!this.solvedProblems.some(p => p.id == id)) {
                    this.myCredits += problem.difficulty;
                    this.solvedProblems.push(problem);
                } 

                return this.myCredits;
            }
        }

        graduate() {
            if (this.myCredits >= this.graduationCredits) {
                return `${this.firstName} ${this.lastName} has graduated succesfully.`;
            } else {
                let neededCredits = this.graduationCredits - this.myCredits;

                return `${this.firstName} ${this.lastName}, you need ${neededCredits} credits to graduate.`;
            }
        }
    }

    return {
        Person,
        Teacher,
        Student,
    }
}

const classes = solveClasses();
const student = new classes.Student("Pesho", "Petrov", 23, [{id: '111', difficulty: 5}, {id: '222', difficulty: 15}]);

student.solveProblem('111');
console.log(student.myCredits);
console.log(student.graduate());

student.solveProblem('222');
console.log(student.solvedProblems);
console.log(student.graduate());
