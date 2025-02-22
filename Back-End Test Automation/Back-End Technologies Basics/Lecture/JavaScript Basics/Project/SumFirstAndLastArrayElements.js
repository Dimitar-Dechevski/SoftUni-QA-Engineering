function solve(input) {
    let firstNumber = Number(input[0]);
    let lastNumber = Number(input[input.length - 1]);
    let result = firstNumber + lastNumber;
    console.log(result);
}

solve([20, 30, 40]);
solve([10, 17, 22, 33]);
solve([11, 58, 69]);