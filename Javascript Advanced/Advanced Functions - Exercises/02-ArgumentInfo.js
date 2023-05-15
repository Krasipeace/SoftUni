function argumentInfo() {
    let counter = {};

    for (let arg of arguments) {
        console.log(`${typeof (arg)}: ${arg}`);

        if (!counter[typeof (arg)]) {
            counter[typeof (arg)] = 1;
        } else if (typeof (arg) === undefined) {
            counter[typeof (arg)] = 0;
        } else {
            counter[typeof (arg)]++;
        }
    }

    let result = Object
        .entries(counter)
        .sort((a, b) => b[1] - a[1]);

    for (let [type, count] of result) {
        console.log(`${type} = ${count}`);
    }
}

argumentInfo('cat', 42, function () { console.log('Hello world!'); });