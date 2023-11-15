function bookShelf(input) {
    let shelves = {};

    for (let line of input) {
        if (line.includes(' -> ')) {
            let [id, genre] = line.split(' -> ');
            createShelf(shelves, id, genre);
        } else {
            let [title, rest] = line.split(': ');
            let [author, genre] = rest.split(', ');
            addBookToShelf(shelves, title, author, genre);
        }
    }

    let sortedShelves = sortShelves(shelves);
    printShelves(sortedShelves);

    function createShelf(shelves, id, genre) {
        if (!shelves.hasOwnProperty(id)) {
            shelves[id] = { genre, books: [] };
        }
    }

    function addBookToShelf(shelves, title, author, genre) {
        for (let id in shelves) {
            if (shelves[id].genre === genre) {
                shelves[id].books.push({ title, author });
                break;
            }
        }
    }

    function sortShelves(shelves) {
        return Object.entries(shelves).sort((a, b) => b[1].books.length - a[1].books.length); // count DESC
    }

    function printShelves(sortedShelves) {
        for (let [id, shelf] of sortedShelves) {
            console.log(`${id} ${shelf.genre}: ${shelf.books.length}`);
            shelf.books.sort((a, b) => a.title.localeCompare(b.title)); // title ASC

            for (let book of shelf.books) {
                console.log(`--> ${book.title}: ${book.author}`);
            }
        }
    }
}

bookShelf([
    '1 -> history', '1 -> action', 'Death in Time: Criss Bell, mystery', '2 -> mystery', '3 -> sci-fi', 'Child of Silver: Bruce Rich, mystery', 'Hurting Secrets: Dustin Bolt, action', 'Future of Dawn: Aiden Rose, sci-fi', 'Lions and Rats: Gabe Roads, history', '2 -> romance', 'Effect of the Void: Shay B, romance', 'Losing Dreams: Gail Starr, sci-fi', 'Name of Earth: Jo Bell, sci-fi', 'Pilots of Stone: Brook Jay, history'
]);
// 3 sci - fi: 3
// --> Future of Dawn: Aiden Rose
// --> Losing Dreams: Gail Starr
// --> Name of Earth: Jo Bell
// 1 history: 2
// --> Lions and Rats: Gabe Roads
// --> Pilots of Stone: Brook Jay
// 2 mystery: 1
// --> Child of Silver: Bruce Rich
console.log('\n');
bookShelf([
    '1 -> mystery', '2 -> sci-fi',
    'Child of Silver: Bruce Rich, mystery',
    'Lions and Rats: Gabe Roads, history',
    'Effect of the Void: Shay B, romance',
    'Losing Dreams: Gail Starr, sci-fi',
    'Name of Earth: Jo Bell, sci-fi'
]);
// 2 sci - fi: 2
// --> Losing Dreams: Gail Starr
// --> Name of Earth: Jo Bell
// 1 mystery: 1
// --> Child of Silver: Bruce Rich