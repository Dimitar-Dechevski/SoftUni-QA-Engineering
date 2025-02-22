function solve(input, rotations) { 
    let effectiveRotations = rotations % input.length;

    while (effectiveRotations > 0) {
        let number = input.shift();
        input.push(number);
        effectiveRotations--;
    }

    console.log(input.join(` `));
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);