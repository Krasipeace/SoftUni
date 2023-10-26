function solve(number) {
    const ages = [
      'baby', 'child', 'teenager', 'adult', 'elder'
    ];

    if (number >= 0 && number <= 2) {
      console.log(ages[0]);
    } else if (number >= 3 && number <= 13) {
      console.log(ages[1]);
    } else if (number >= 14 && number <= 19) {
      console.log(ages[2]);
    } else if (number >= 20 && number <= 65) {
      console.log(ages[3]);
    } else if (number >= 66) {
      console.log(ages[4]);
    } else {
      console.log('out of bounds');
    }
}

solve(20); // adult
solve(1); // baby
solve(100); // elder
solve(8); // child
solve(14); // teenager
solve(-1); // out of bounds