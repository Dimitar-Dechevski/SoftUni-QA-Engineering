function solve(n, input) {

    let numbers = [];
    let count = 0;

    for (let i = n - 1; i >= 0; i--) {
        numbers[count] = input[i];
        count++;
    }

    console.log(numbers.join(` `));
}

solve(3, [10, 20, 30, 40, 50]);
solve(4, [-1, 20, 99, 5]);
solve(2, [66, 43, 75, 89, 47]);