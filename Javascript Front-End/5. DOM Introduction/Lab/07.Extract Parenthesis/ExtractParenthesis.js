function extract(content) {
    let element = document.getElementById(content);
    let text = element.textContent;
    let pattern = /\(([^)]+)\)/g;
    let result = [];

    let match = pattern.exec(text);
    while (match) {
        result.push(match[1]);
        match = pattern.exec(text);
    }

    return element.textContent = result.join('; ');
}