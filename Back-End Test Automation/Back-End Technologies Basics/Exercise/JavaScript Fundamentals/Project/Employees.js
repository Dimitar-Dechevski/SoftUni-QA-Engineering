function solve(input) {
    let employees = {};

    for (let person of input) {
        let personalNumber = person.length;
        let name = person;
        employees[name] = personalNumber
    }

    for (let employee in employees) {
        console.log(`Name: ${employee} -- Personal Number: ${employees[employee]}`)
    }

}

solve(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
solve(['Samuel Jackson', 'Will Smith', 'Bruce Willis', 'Tom Holland']);