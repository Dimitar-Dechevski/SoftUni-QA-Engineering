function solve(product, quantity) {
    let price;
    let result;

    switch (product) {
        case 'coffee':
            price = 1.50;
            break;
        case 'water':
            price = 1.00;
            break;
        case 'coke':
            price = 1.40;
            break;
        case 'snacks':
            price = 2.00;
            break;
    }

    result = quantity * price;
    console.log(result.toFixed(2));
}

solve('water', 5);
solve('coffee', 2);