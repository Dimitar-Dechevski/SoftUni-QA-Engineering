function solve(input) {

    let isSameDigit = true;
    let result = 0;
    let symbol;
    let number = parseInt(input)
    let counter = 0;

    while (number > 0) {
        let digit = number % 10;
        number = Math.floor(number / 10);

        if (counter === 0) {
            symbol = digit;
            counter++;
        }

        if (digit === symbol) {
            isSameDigit = true;
        } else {
            isSameDigit = false;
            break;
        }
    }

    number = parseInt(input);

    while (number > 0) {
        let digit = number % 10;
        result += digit;
        number = Math.floor(number / 10);
    }

    console.log(isSameDigit);
    console.log(result);
}

solve(2222222);
solve(1234);