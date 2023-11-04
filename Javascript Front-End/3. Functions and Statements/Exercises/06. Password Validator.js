function passwordValidator(password) {
    const lengthChecker = password.length >= 6 && password.length <= 10;
    const digitsChecker = /\d.*\d/.test(password);
    const lettersAndDigitsChecker = /^[A-Za-z0-9]+$/.test(password);
    let isValid = true;

    if (!lengthChecker) {
        console.log("Password must be between 6 and 10 characters");
        isValid = false;
    }

    if (!lettersAndDigitsChecker) {
        console.log("Password must consist only of letters and digits");
        isValid = false;
    }

    if (!digitsChecker) {
        console.log("Password must have at least 2 digits");
        isValid = false;
    }

    if (isValid) {
        console.log("Password is valid");
    }
}

passwordValidator('logIn'); // Password must be between 6 and 10 characters // Password must have at least 2 digits
passwordValidator('MyPass123'); // Password is valid 
passwordValidator('Pa$s$s'); // Password must consist only of letters and digits // Password must have at least 2 digits