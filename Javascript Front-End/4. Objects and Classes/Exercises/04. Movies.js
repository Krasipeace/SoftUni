function getMoviesInfo(input) {
    let movies = [];

    function addMovie(current) {
        let name = current.slice(1).join(' ');
        movies.push({ name: name });
    }

    function addDirector(current) {
        let index = current.indexOf('directedBy');
        let name = current.slice(0, index).join(' ');
        let director = current.slice(index + 1).join(' ');

        movies.forEach(movie => {
            if (movie.name === name) {
                movie.director = director;
            }
        });
    }

    function addDate(current) {
        let index = current.indexOf('onDate');
        let name = current.slice(0, index).join(' ');
        let date = current.slice(index + 1).join(' ');

        movies.forEach(movie => {
            if (movie.name === name) {
                movie.date = date;
            }
        });
    }
    
    function processMovie(input) {
        for (let i = 0; i < input.length; i++) {
            let current = input[i].split(' ');

            switch (true) {
                case current[0] === 'addMovie':
                    addMovie(current);
                    break;
                case current.includes('directedBy'):
                    addDirector(current);
                    break;
                case current.includes('onDate'):
                    addDate(current);
                    break;
            }
        }
    }

    function printMovies(movies) {
        movies.forEach(movie => {
            if (movie.name && movie.director && movie.date) {
                console.log(JSON.stringify(movie));
            }
        });
    }

    processMovie(input);
    printMovies(movies);
}

getMoviesInfo([
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
getMoviesInfo([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
]);
// {"name":"The Avengers","director":"Anthony Russo","date":"30.07.2010"}