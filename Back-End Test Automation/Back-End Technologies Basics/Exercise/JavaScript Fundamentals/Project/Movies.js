function solve(movies) {
    let cinema = {};
    let name;
    let tokens;
    let director;
    let date;

    for (let movie of movies) {
        if (movie.includes('addMovie')) {
            tokens = movie.split('addMovie ');
            name = tokens[1];
            cinema[name] = {
                name: name
            }
        } else if (movie.includes('directedBy')) {
            tokens = movie.split(' directedBy ');
            name = tokens[0];
            director = tokens[1];

            if (cinema.hasOwnProperty(name)) {
                cinema[name].director = director;
            }

        } else if (movie.includes('onDate')) {
            tokens = movie.split(' onDate ');
            name = tokens[0];
            date = tokens[1];

            if (cinema.hasOwnProperty(name)) {
                cinema[name].date = date;
            }
        }
    }

    for (let film in cinema) {
        if (cinema[film].name !== undefined && cinema[film].director !== undefined && cinema[film].date !== undefined) {
            console.log(JSON.stringify(cinema[film]));
        }
    }
    
}

solve(['addMovie Fast and Furious', 'addMovie Godfather', 'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola', 'Godfather onDate 29.07.2018', 'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018', 'Fast and Furious directedBy Rob Cohen']);
solve(['addMovie The Avengers', 'addMovie Superman', 'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010', 'Captain America onDate 30.07.2010', 'Captain America directedBy Joe Russo']);