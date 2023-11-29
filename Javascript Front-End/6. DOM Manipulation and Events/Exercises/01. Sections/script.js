function create(words) {
    let content = document.getElementById('content');

    for (let word of words) {
        let div = document.createElement('div');
        let p = document.createElement('p');
        p.textContent = word;
        p.style.display = 'none';
        div.appendChild(p);
        div.addEventListener('click', show);
        content.appendChild(div);
    }

    function show(e) {
        e.target.firstChild.style.display = 'block';
    }
}