function solve(groupOfPeople, typeOfGroup, dayOfWeek) {
    const prices = {
      'Students': {'Friday': 8.45, 'Saturday': 9.80, 'Sunday': 10.46},
      'Business': {'Friday': 10.90, 'Saturday': 15.60, 'Sunday': 16},
      'Regular': {'Friday': 15, 'Saturday': 20, 'Sunday': 22.50}
    };
  
    let totalPrice = prices[typeOfGroup][dayOfWeek] * groupOfPeople;
  
    if (typeOfGroup === 'Students' && groupOfPeople >= 30) {
      totalPrice *= 0.85;
    } else if (typeOfGroup === 'Business' && groupOfPeople >= 100) {
      totalPrice -= 10 * prices[typeOfGroup][dayOfWeek];
    } else if (typeOfGroup === 'Regular' && groupOfPeople >= 10 && groupOfPeople <= 20) {
      totalPrice *= 0.95;
    } 
  
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

solve(30, 'Students', 'Sunday'); // Total price: 266.73
solve(40, 'Regular', 'Saturday'); // Total price: 800.00