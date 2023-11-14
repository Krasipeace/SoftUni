function categorizeAge(number) {
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

categorizeAge(20); // adult
categorizeAge(1); // baby
categorizeAge(100); // elder
categorizeAge(8); // child
categorizeAge(14); // teenager
categorizeAge(-1); // out of bounds