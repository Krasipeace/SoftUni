function solve() {
    let text = document.getElementById('input').value;
    let sentences = text.split('.').filter(x => x !== '');
    let output = document.getElementById('output');

    for (let i = 0; i < sentences.length; i += 3) {
        let paragraph = document.createElement('p');
        paragraph.textContent = sentences.slice(i, i + 3).join('.') + '.';
        output.appendChild(paragraph);
    }
}