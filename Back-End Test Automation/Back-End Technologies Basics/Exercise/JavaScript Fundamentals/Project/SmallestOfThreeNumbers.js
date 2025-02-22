function solve(num1, num2, num3) {

    if (num1 <= num2 && num1 <= num3) {
        console.log(num1);
    } else if (num2 <= num1 && num2 <= num3) {
        console.log(num2);
    } else if (num3 <= num1 && num3 <= num2) {
        console.log(num3);
    }
    
}

solve(2, 5, 3);
solve(600, 342, 123);
solve(25, 21, 4);
solve(2, 2, 2);