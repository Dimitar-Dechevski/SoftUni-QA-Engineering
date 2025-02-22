function solve(firstArray, secondArray) {
    let products = {};
    let productName;
    let productQuantity;

    for (let i = 0; i < firstArray.length; i++) {
        if (i % 2 === 0) {
            productName = firstArray[i];
        } else {
            productQuantity = Number(firstArray[i]);
            products[productName] = productQuantity;
        }
    }

    for (let k = 0; k < secondArray.length; k++) {
        if (k % 2 === 0) {
            productName = secondArray[k];
        } else {
            productQuantity = Number(secondArray[k]);

            if (products.hasOwnProperty(productName)) {
                products[productName] = products[productName] + productQuantity;
            } else {
                products[productName] = productQuantity;
            }
        }
    }

    for (let product in products) {
        console.log(`${product} -> ${products[product]}`);
    }
    
}

solve(['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'], ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']);
solve(['Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'], ['Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30']);