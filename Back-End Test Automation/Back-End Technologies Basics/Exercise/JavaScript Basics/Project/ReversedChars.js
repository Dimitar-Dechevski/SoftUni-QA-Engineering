function solve(input) {

    let symbols = [];

    for (let i = input.length - 1; i >= 0; i--) {
        symbols.push(input[i]);
    }

    console.log(symbols.join(` `));
}

solve(['A', 'B', 'C']);
solve(['1', 'L', '&']);