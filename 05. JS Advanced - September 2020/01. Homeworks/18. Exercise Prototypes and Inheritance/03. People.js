function solve() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            let task = this.tasks.shift();
            console.log(`${this.name} ${task}`);
            this.tasks.push(task);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push('is working on a simple task.');
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push('is working on a complicated task.');
            this.tasks.push('is taking time off work.');
            this.tasks.push('is supervising junior workers.');
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;
            this.tasks.push(`scheduled a meeting.`);
            this.tasks.push(`is preparing a quarterly report.`);
        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return {
        Employee,
        Junior, 
        Senior,
        Manager,
    }
}

let app = solve();
let manager = new app.Manager('pesho', 22);
manager.dividend = 50;
manager.salary = 2000;
manager.collectSalary();
manager.work();
manager.work();
manager.work();
manager.work();

var guy1 = new app.Junior('dragan', 23);
guy1.salary = 1000;
guy1.collectSalary();