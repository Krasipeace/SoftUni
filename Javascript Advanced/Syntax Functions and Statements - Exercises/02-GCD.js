function gcd(numberOne, numberTwo) {
    let gcd = 1;
    let big = Math.max(numberOne, numberTwo);
    let small = Math.min(numberOne, numberTwo);

    for (let i = 1; i <= small; i++) {
        if (big % i == 0 && small % i == 0) {
            gcd = i;
        }
    }

    console.log(gcd);
}

gcd(15, 5); // 5
gcd(2154, 458) // 2