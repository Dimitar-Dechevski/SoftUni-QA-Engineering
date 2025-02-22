function solve(input) {
    let result = [];
    let count = 0;
    let minIndex;
    let maxIndex

    while (input.length !== 0) {

        let max = Number.MIN_VALUE;
        let min = Number.MAX_VALUE;

        for (let i = 0; i < input.length; i++) {
            let number = input[i];

            if (min > number) {
                min = number;
                minIndex = i;
            }

            if (max < number) {
                max = number;
                maxIndex = i;
            }
        }

        if (count % 2 == 0) {
            result.push(min);
            input.splice(minIndex, 1);
            count++;
        } else {
            result.push(max);
            input.splice(maxIndex, 1);
            count++
        }
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));