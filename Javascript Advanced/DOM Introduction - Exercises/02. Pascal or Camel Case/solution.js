function solve() {
    let text = document.getElementById('text').value;
    let convention = document.getElementById('naming-convention').value;
    let result = document.getElementById('result');

    let words = text.split(' ').map(x => x.toLowerCase());

    if (convention === 'Camel Case') {
        words = words.map((x, i) => i !== 0 ? x[0].toUpperCase() + x.slice(1) : x);
    } else if (convention === 'Pascal Case') {
        words = words.map(x => x[0].toUpperCase() + x.slice(1));
    } else {
        result.textContent = 'Error!';
        return;
    }

    result.textContent = words.join('');
}