function solve(input) {
    let parking = [];
    let command;
    let carNumber;

    for (let i = 0; i < input.length; i++) {
        let tokens = input[i].split(', ');
        command = tokens[0];
        carNumber = tokens[1];

        if (command === 'IN' && !parking.includes(carNumber)) {
            parking.push(carNumber);
        } else if (command === 'OUT' && parking.includes(carNumber)) {
            let index = parking.indexOf(carNumber);
            parking.splice(index, 1);
        }
    }

    if (parking.length === 0) {
        console.log(`Parking Lot is Empty`);
    } else {
        parking.sort((carNumber1, carNumber2) => carNumber1.localeCompare(carNumber2));

        for (let car of parking) {
            console.log(car);
        }
    }
}

solve(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'IN, CA9999TT', 'IN, CA2866HI', 'OUT, CA1234TA', 'IN, CA2844AA', 'OUT, CA2866HI', 'IN, CA9876HH', 'IN, CA2822UU']);
solve(['IN, CA2844AA', 'IN, CA1234TA', 'OUT, CA2844AA', 'OUT, CA1234TA']);