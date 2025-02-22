function solve(input) {

    let speed = input[0];
    let area = input[1];
    let limit;
    let difference;
    let infractionStatus;

    switch (area) {
        case 'motorway':
            limit = 130;
            break;
        case 'interstate':
            limit = 90;
            break;
        case 'city':
            limit = 50;
            break;
        case 'residential':
            limit = 20;
            break;
    }

    if (speed <= limit) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    } else {

        difference = speed - limit;

        if (difference <= 20) {
            infractionStatus = 'speeding';
        } else if (difference <= 40) {
            infractionStatus = 'excessive speeding';
        } else {
            infractionStatus = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${infractionStatus}`); 
    }
    
}

solve([40, 'city']);
solve([21, 'residential']);
solve([120, 'interstate']);
solve([200, 'motorway']);