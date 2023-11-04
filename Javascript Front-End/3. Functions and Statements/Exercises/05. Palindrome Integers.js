function isPalindrome(arr) {
    for (let i = 0; i < arr.length; i++) {
        let number = arr[i].toString();
        let reversed = number.split('').reverse().join('');
        if (number === reversed) {
            console.log(true);
        } else {
            console.log(false);
        }
    }
}

isPalindrome([123, 323, 421, 121]); // false true false true
isPalindrome([32, 2, 232, 1010]); // false true true false