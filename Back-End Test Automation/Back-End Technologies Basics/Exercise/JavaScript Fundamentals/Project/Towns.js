function solve(cities) {
    for (let city of cities) {
        let tokens = city.split(' | ');
        let town = tokens[0];
        let latitude = Number(tokens[1]).toFixed(2);
        let longitude = Number(tokens[2]).toFixed(2);
        let townObject = {
            town: town,
            latitude: latitude,
            longitude: longitude
        }
        console.log(townObject);
    }
}

solve(['Sofia | 42.696552 | 23.32601', 'Beijing | 39.913818 | 116.363625']);
solve(['Plovdiv | 136.45 | 812.575']);