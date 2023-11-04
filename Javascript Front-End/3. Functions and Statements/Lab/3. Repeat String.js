function solve(string, count) {
    let result = '';
    for (let i = 0; i < count; i++) {
        result += string;
    }
    
    return result;
}

console.log(solve('abc', 3)); //abcabcabc
console.log(solve('String', 2)); //StringString