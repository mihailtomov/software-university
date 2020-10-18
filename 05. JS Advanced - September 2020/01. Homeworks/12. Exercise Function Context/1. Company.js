class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department) {
            throw new Error('Invalid input!');
        }
        if (salary < 0) {
            throw new Error('Invalid input!');
        }
        let employee = {username, salary, position};

        let currDepartment = {department};

        currDepartment.employees = [];

        if (!this.departments.some(x => x.department == department)) {
            this.departments.push(currDepartment);
        } 

        this.departments.find(x => x.department == department).employees.push(employee);

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartmentName;
        let highestAverageSalary = 0;
        let bestDepartment;

        this.departments.forEach(department => {
            let employees = department.employees;

            let currentAverageSalary = employees.reduce((acc, curr) => {
                acc += curr.salary;
                
                return acc;
            }, 0) / employees.length;

            if (currentAverageSalary > highestAverageSalary) {
                highestAverageSalary = currentAverageSalary;
                bestDepartmentName = department.department;
                bestDepartment = department;
            }
        });

        let bestEmployees = bestDepartment.employees.sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username));

        let output = `Best Department is: ${bestDepartmentName}\n`;
        output += `Average salary: ${highestAverageSalary.toFixed(2)}\n`;

        bestEmployees.forEach(e => {
            output += `${e.username} ${e.salary} ${e.position}\n`
        });

        return output.trim();
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());