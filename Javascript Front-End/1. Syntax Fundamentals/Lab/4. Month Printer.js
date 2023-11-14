function getMonthByNumber(number) {
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

getMonthByNumber(2); // February
getMonthByNumber(13); // Error!
getMonthByNumber(-2); // Error!
getMonthByNumber(0); // Error!