function solve(firstChar, secondChar, thirdChar) {
    console.log(`${[...arguments].reverse().join(' ')}`);
}

solve('A', 'B', 'C'); // C B A
solve('1', 'L', '&'); // & L 1
solve('a', 'b', 'c'); // c b a