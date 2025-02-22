function solve(number1, number2, mathOperator) {
    
    switch (mathOperator) {
        case '+':
            console.log(number1 + number2);
            break;
        case '-':
            console.log(number1 - number2);
            break;
        case '*':
            console.log(number1 * number2);
            break;
        case '/':
            console.log(number1 / number2);
            break;
        case '%':
            console.log(number1 % number2);
            break;
        case '**':
            console.log(number1 ** number2);
            break;
    }
    
}

solve(5, 6, '+');
solve(3, 5.5, '*');