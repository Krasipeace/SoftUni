function movies(input) {
    let movies = [];
    let index = -1;
    let name = "";
    let director = "";
    
    for (let i = 0; i < input.length; i++) {
        let current = input[i].split(' ');

        switch (true) {
            case current[0] === 'addMovie':
                name = current.slice(1).join(' ');
                movies.push({ name: name });
                break;
            case current.includes('directedBy'):
                index = current.indexOf('directedBy');
                name = current.slice(0, index).join(' ');
                director = current.slice(index + 1).join(' ');

                movies.forEach(movie => {
                    if (movie.name === name) {
                        movie.director = director;
                    }
                });
                break;
            case current.includes('onDate'):
                index = current.indexOf('onDate');
                name = current.slice(0, index).join(' ');
                date = current.slice(index + 1).join(' ');

                movies.forEach(movie => {
                    if (movie.name === name) {
                        movie.date = date;
                    }
                });
                break;
        }
    }

    movies.forEach(movie => {
        if (movie.name && movie.director && movie.date) {
            console.log(JSON.stringify(movie));
        }
    });
}

movies([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]);
// {"name":"Fast and Furious","director":"Rob Cohen","date":"30.07.2018"}
// {"name":"Godfather","director":"Francis Ford Coppola","date":"29.07.2018"}
movies([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
]);
// {"name":"The Avengers","director":"Anthony Russo","date":"30.07.2010"}