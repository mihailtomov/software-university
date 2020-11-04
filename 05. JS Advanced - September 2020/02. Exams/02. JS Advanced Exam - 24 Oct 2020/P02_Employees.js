function solveClasses() {
    class Developer {
        constructor(firstName, lastName) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.experience = 0;
            this.tasks = [];
        }

        addTask(id, taskName, priority) {
            if (priority == 'high') {
                this.tasks.unshift({ id, taskName, priority });
            } else {
                this.tasks.push({ id, taskName, priority });
            }

            return `Task id ${id}, with ${priority} priority, has been added.`;
        }

        doTask() {
            if (this.tasks.length < 1) {
                return `${this.firstName}, you have finished all your tasks. You can rest now.`;
            }

            let task = this.tasks.shift();

            return `${task.taskName}`;
        }

        getSalary() {
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`;
        }

        reviewTasks() {
            if (this.tasks.length > 0) {
                let output = 'Tasks, that need to be completed:\n';

                this.tasks.forEach(task => {
                    output += `${task.id}: ${task.taskName} - ${task.priority}\n`;
                });

                return output.trim();
            }
        }
    }

    class Junior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.bonus = bonus;
            this.experience = experience;
            this.baseSalary = 1000 + bonus;
        }

        learn(years) {
            this.experience += years;
        }
    }

    class Senior extends Developer {
        constructor(firstName, lastName, bonus, experience) {
            super(firstName, lastName);
            this.bonus = bonus;
            this.experience = experience + 5;
            this.baseSalary = 1000 + bonus;
        }

        changeTaskPriority(taskId) {
            let task = this.tasks.find(t => t.id == taskId);

            if (task.priority == 'high') {
                task.priority = 'low';
            } else {
                task.priority = 'high';
            }

            this.tasks = this.tasks.filter(t => t != task);

            if (task.priority == 'high') {
                this.tasks.unshift(task);
            } else {
                this.tasks.push(task);
            }

            return task;       
        }
    }

    return {
        Developer,
        Junior,
        Senior,
    }
}

let classes = solveClasses();
const developer = new classes.Developer("George", "Joestar");
console.log(developer.addTask(1, "Inspect bug", "low"));
console.log(developer.addTask(2, "Update repository", "high"));
console.log(developer.reviewTasks());
console.log(developer.getSalary());

const junior = new classes.Junior("Jonathan", "Joestar", 200, 2);
console.log(junior.getSalary());

const senior = new classes.Senior("Joseph", "Joestar", 200, 2);
senior.addTask(1, "Create functionality", "low");
senior.addTask(2, "Update functionality", "high");
console.log(senior.changeTaskPriority(1)["priority"]);