function solve(number) {
    const months = [
      'January', 'February', 'March', 'April', 'May', 'June',
      'July', 'August', 'September', 'October', 'November', 'December'
    ];
  
    if (number >= 1 && number <= 12) {
      console.log(months[number - 1]);
    } else {
      console.log('Error!');
    }
}

solve(2); // February
solve(13); // Error!
solve(-2); // Error!
solve(0); // Error!