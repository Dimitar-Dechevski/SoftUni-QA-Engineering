function solve(input) {

    let result;
    let price;
    let people = parseInt(input[0]);
    let type = input[1]
    let day = input[2];

    switch (day) {
        case 'Friday':
            if (type === 'Students') {
                price = 8.45;
            } else if (type === 'Business') {
                price = 10.90;
            } else if (type === 'Regular') {
                price = 15.00;
            }
            break;
        case 'Saturday':
            if (type === 'Students') {
                price = 9.80;
            } else if (type === 'Business') {
                price = 15.60;
            } else if (type === 'Regular') {
                price = 20.00;
            }
            break;
        case 'Sunday':
            if (type === 'Students') {
                price = 10.46;
            } else if (type === 'Business') {
                price = 16.00;
            } else if (type === 'Regular') {
                price = 22.50;
            }
            break;
    }

    if (type === 'Students' && people >= 30) {
        result = people * price;
        result = result - (result * 0.15);
    } else if (type === 'Business' && people >= 100) {
        result = (people - 10) * price;
    } else if (type === 'Regular' && people >= 10 && people <= 20) {
        result = people * price;
        result = result - (result * 0.05);
    } else {
        result = people * price;
    }

    console.log(`Total price: ${result.toFixed(2)}`);
}

solve([30, 'Students', 'Sunday']);
solve([40, 'Regular', 'Saturday']);