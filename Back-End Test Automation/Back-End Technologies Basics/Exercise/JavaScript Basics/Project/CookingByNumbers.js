function solve(input) {

    let number = input[0];

    for (let i = 1; i < input.length; i++) {

        let command = input[i];

        if (command === 'chop') {
            number = Math.floor(number / 2);
        } else if (command === 'dice') {
            number = Math.floor(Math.sqrt(number));
        } else if (command === 'spice') {
            number = number + 1;
        } else if (command === 'bake') {
            number = number * 3;
        } else if (command === 'fillet') {
            number = number - (number * 0.20);
        }

        console.log(number);
    }
    
}

solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']);
solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']);