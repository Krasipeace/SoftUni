function solution() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
            this._currentTask = 0;
        }

        work() {
            if (this._currentTask === this.tasks.length) {
                this._currentTask = 0;
            }

            console.log(this.name + this.tasks[this._currentTask]);
            this._currentTask++;
        }

        collectSalary() {
            return console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [` is working on a simple task.`];
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [
                ` is working on a complicated task.`,
                ` is taking time off work.`,
                ` is supervising junior workers.`
            ];
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [
                ` scheduled a meeting.`,
                ` is preparing a quarterly report.`
            ];
            this.dividend = 0;
        }

        collectSalary() {
            return console.log(`${this.name} received ${this.salary + this.dividend} this month.`);
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}

let classes = solution();
let junior = new classes.Junior('Ivan', 25);
junior.salary = 1000; 
junior.work();
junior.work();
junior.salary = 1200;
junior.collectSalary();
