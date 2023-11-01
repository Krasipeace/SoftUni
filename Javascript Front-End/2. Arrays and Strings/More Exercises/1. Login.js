function solve (input) {
    const username = input.shift();
    const password = username.split('').reverse().join('');
    let currentPassword = input.shift();
    let count = 0;
    
    while (currentPassword !== password) {
        count++;

        if (count === 4) {
            console.log(`User ${username} blocked!`);
            break;
        }

        currentPassword = input.shift();
        console.log('Incorrect password. Try again.');
    }

    if (currentPassword === password) {
        console.log(`User ${username} logged in.`);
    }
}

solve(['Acer','login','go','let me in','recA']) // Incorrect password. Try again. Incorrect password. Try again. ncorrect password. Try again. User Acer logged in.
solve(['momo','omom']) // User momo logged in.
solve(['sunny','rainy','cloudy','sunny','not sunny']) // Incorrect password. Try again. Incorrect password. Try again. Incorrect password. Try again. User sunny blocked!