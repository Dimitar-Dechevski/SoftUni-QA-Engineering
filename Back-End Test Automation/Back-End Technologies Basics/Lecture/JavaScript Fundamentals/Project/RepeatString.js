function solve(input, count) {
    let text = input.repeat(count);
    return text;
}

console.log(solve('abc', 3));
console.log(solve('String', 2));