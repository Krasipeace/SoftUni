function employees(input) {
    let employees = [];

    for (let i = 0; i < input.length; i++) {
        let employee = {
            name: input[i],
            personalNumber: input[i].length
        }

        employees.push(employee);
    }

    employees.forEach(employee => {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`);
    })
}

employees(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
// Name: Silas Butler -- Personal Number: 12
// Name: Adnaan Buckley -- Personal Number: 14
// Name: Juan Peterson -- Personal Number: 13
// Name: Brendan Villarreal -- Personal Number: 18