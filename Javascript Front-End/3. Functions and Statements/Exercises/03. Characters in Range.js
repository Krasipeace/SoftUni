function charsInRange(startChar, endChar) {
    let start = startChar.charCodeAt(0);
    let end = endChar.charCodeAt(0);
    let result = [];

    if (start > end) {
        [start, end] = [end, start];
    }

    for (let i = start + 1; i < end; i++) {
        result.push(String.fromCharCode(i));
    }

    return result.join(' ');
}

console.log(charsInRange('a', 'd')); // b c
console.log(charsInRange('#', ':')); // $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9
console.log(charsInRange('C', '#')); // $ % & ' ( ) * + , - . / 0 1 2 3 4 5 6 7 8 9 : ; < = > ? @ A B