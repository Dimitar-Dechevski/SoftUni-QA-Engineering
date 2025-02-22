function solve(num1, num2, num3) {

    function sum(num1, num2) {
        return num1 + num2;
    }

    function subtract(sumResult, num3) {
        return sumResult - num3;
    }

    let sumResult = sum(num1, num2);
    let result = subtract(sumResult, num3);
    console.log(result);
}

solve(23, 6, 10);
solve(1, 17, 30);
solve(42, 58, 100);