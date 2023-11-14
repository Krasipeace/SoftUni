function printRangeNumbers(startNumber, endNumber) {
    if (startNumber < endNumber) {
        for (let i = startNumber; i <= endNumber; i++) {
          console.log(i);
        }
    } else {
        for (let i = startNumber; i >= endNumber; i--) {
          console.log(i);
        }
    }
}

printRangeNumbers(1, 5); // 1 2 3 4 5
printRangeNumbers(-5, 5); // -5 -4 -3 -2 -1 0 1 2 3 4 5