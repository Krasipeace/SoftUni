function solve(...elements) {
    let number = Number(elements.shift());
    const operations = {
        'chop': (num) => num / 2,
        'dice': (num) => Math.sqrt(num),
        'spice': (num) => num + 1,
        'bake': (num) => num * 3,
        'fillet': (num) => num * 0.8
    };
  
    for (let i = 0; i < elements.length; i++) {
        number = operations[elements[i]](number);
        console.log(Number.isInteger(number) ? number : number.toFixed(1));
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop'); // 16 8 4 2 1
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet'); // 3 4 2 6 4.8