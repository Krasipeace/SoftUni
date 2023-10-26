function solve(typeOfDay, personAge) {
    const prices = {
      'Weekday': [12, 18, 12],
      'Weekend': [15, 20, 15],
      'Holiday': [5, 12, 10]
    };
  
    let ticketPrice = prices[typeOfDay][getTicketPrice(personAge)];
  
    if (ticketPrice === undefined) {
      console.log('Error!');
    } else {
      console.log(`${ticketPrice}$`);
    }

    function getTicketPrice(personAge) {
        if (personAge >= 0 && personAge <= 18) {
            return 0;
        } else if (personAge > 18 && personAge <= 64) {
            return 1;
        } else if (personAge > 64 && personAge <= 122) {
            return 2;
        } else {
            return -1;
        }
    }
}

solve('Weekday', 42); // 18$
solve('Holiday', -12); // Error!
solve('Holiday', 15); // 5$
solve('Weekend', 3); // 15$
solve('Weekend', 123); // Error!