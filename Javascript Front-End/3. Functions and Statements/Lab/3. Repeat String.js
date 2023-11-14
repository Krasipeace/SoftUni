function multiplyString(string, multiplier) {
    let result = '';
    for (let i = 0; i < multiplier; i++) {
        result += string;
    }
    
    return result;
}

console.log(multiplyString('abc', 3)); //abcabcabc
console.log(multiplyString('String', 2)); //StringString