function solve(number) {

    let result = 0;

    while (number > 0) {
        let digit = number % 10;
        result += digit;
        number = Math.floor(number / 10);
    }

    console.log(result);
}

solve(245678);
solve(97561);
solve(543);