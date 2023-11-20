function colorize() {
    let rows = document.querySelectorAll('table tr:nth-child(even)');

    for (let row of rows) {
        row.style.background = 'teal';
    }
}