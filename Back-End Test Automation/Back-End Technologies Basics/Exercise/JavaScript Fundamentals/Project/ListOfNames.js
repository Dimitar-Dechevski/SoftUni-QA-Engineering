function solve(input) {
    let result = input.sort((name1, name2) =>
        name1.localeCompare(name2));

    for (let i = 0; i < result.length; i++) {
        console.log(`${i + 1}.${input[i]}`);
    }
}

solve(["John", "Bob", "Christina", "Ema"]);