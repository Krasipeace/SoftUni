function solve(year) {
    if ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) {
      console.log('yes');
    } else {
      console.log('no');
    }
}

solve(1984); // yes
solve(2003); // no
solve(4); // yes