function solve(input) {
    let fruit = input[0];
    let grams = input[1];
    let kilogramPrice = input[2];
    let kilograms = grams / 1000;
    let result = kilograms * kilogramPrice;
    console.log(`I need $${result.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`)
}

solve(['orange', 2500, 1.80]);
solve(['apple', 1563, 2.35]);