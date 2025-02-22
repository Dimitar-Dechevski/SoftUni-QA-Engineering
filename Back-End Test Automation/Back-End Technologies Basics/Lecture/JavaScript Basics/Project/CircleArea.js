function solve(number) {

    let type = typeof(number);

    if (type === 'number') {
        let result = (number ** 2) * Math.PI;
        console.log(result.toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we received a ${type}.`);
    }
    
}

solve(5);
solve('name');