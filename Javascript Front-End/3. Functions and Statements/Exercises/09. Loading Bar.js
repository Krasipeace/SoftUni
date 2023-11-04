function loadingBar(number) { 
    const loadingBarLength = 10;
    const completePercentage = 100;
    let loadingBar = '';
    let percentage = number / loadingBarLength;
    let dots = loadingBarLength - percentage;

    if (number === completePercentage) {
        loadingBar = '100% Complete!\n[%%%%%%%%%%]';
    } else {
        loadingBar = `${number}% [${'%'.repeat(percentage)}${'.'.repeat(dots)}]\nStill loading...`;
    }

    return loadingBar;
}

console.log(loadingBar(30)); // 30% [%%%.......]
console.log(loadingBar(50)); // 50% [%%%%%.....]
console.log(loadingBar(100)); // 100% Complete!