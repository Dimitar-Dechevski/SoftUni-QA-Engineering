function solve(input) {

    let startIndex = parseInt(input[0]);
    let endIndex = parseInt(input[1]);
    let result = 0;
    let numbers = [];

    for (let i = startIndex; i <= endIndex; i++) {
        numbers.push(i);
        result += i;
    }

    console.log(numbers.join(` `));
    console.log(`Sum: ${result}`);
}

solve([5, 10]);
solve([0, 26]);
solve([50, 60]);