function solve(firstName, lastName, age) {
    age = Number(age);

    let person = {
        firstName: firstName,
        lastName: lastName,
        age: age
    };

    return person;
}

console.log(solve('Peter', 'Pan', '20'));
console.log(solve('George', 'Smith', '18'));