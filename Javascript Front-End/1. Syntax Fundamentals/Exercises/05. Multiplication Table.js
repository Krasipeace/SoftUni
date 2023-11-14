function multiplyTable(number) {
    for (let i = 1; i <= 10; i++) {
      let result = number * i;
      console.log(`${number} X ${i} = ${result}`);
    }
}

multiplyTable(5); // 5 X 1 = 5 5 X 2 = 10 5 X 3 = 15 5 X 4 = 20 5 X 5 = 25 5 X 6 = 30 5 X 7 = 35 5 X 8 = 40 5 X 9 = 45 5 X 10 = 50
multiplyTable(-5); // -5 X 1 = -5 -5 X 2 = -10 -5 X 3 = -15 -5 X 4 = -20 -5 X 5 = -25 -5 X 6 = -30 -5 X 7 = -35 -5 X 8 = -40 -5 X 9 = -45 -5 X 10 = -50