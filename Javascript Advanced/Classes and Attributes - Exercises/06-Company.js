class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!');
        }

        let currentDepartment = this.departments.find(d => d.name === department);

        if (!currentDepartment) {
            currentDepartment = {
                name: department,
                employees: []
            };

            this.departments.push(currentDepartment);
        }

        currentDepartment.employees.push({
            username,
            salary,
            position
        });

        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = this.departments.sort((a, b) => {
            let aAverageSalary = a.employees.reduce((acc, e) => acc + e.salary, 0) / a.employees.length;
            let bAverageSalary = b.employees.reduce((acc, e) => acc + e.salary, 0) / b.employees.length;

            return (bAverageSalary - aAverageSalary);
        })[0];

        let result = `Best Department is: ${bestDepartment.name}\n`;
        result += `Average salary: ${(bestDepartment.employees.reduce((acc, e) => acc + e.salary, 0) / bestDepartment.employees.length).toFixed(2)}\n`;

        bestDepartment.employees
            .sort((a, b) => b.salary - a.salary || a.username.localeCompare(b.username))
            .forEach(e => result += `${e.username} ${e.salary} ${e.position}\n`);

        return result.trim();
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