function reversedChars(firstChar, secondChar, thirdChar) {
    console.log(`${[...arguments].reverse().join(' ')}`);
}

reversedChars('A', 'B', 'C'); // C B A
reversedChars('1', 'L', '&'); // & L 1
reversedChars('a', 'b', 'c'); // c b a