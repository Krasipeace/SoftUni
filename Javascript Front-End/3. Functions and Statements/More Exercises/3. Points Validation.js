function pointsValidation(params) {
    const x1 = Number(params[0]);
    const y1 = Number(params[1]);
    const x2 = Number(params[2]);
    const y2 = Number(params[3]);

    const distance1 = Math.sqrt(Math.pow(x1, 2) + Math.pow(y1, 2));
    const distance2 = Math.sqrt(Math.pow(x2, 2) + Math.pow(y2, 2));
    const distance3 = Math.sqrt(Math.pow((x1 - x2), 2) + Math.pow((y1 - y2), 2));

    console.log(Number.isInteger(distance1)
        ? `{${x1}, ${y1}} to {0, 0} is valid`
        : `{${x1}, ${y1}} to {0, 0} is invalid`);

    console.log(Number.isInteger(distance2)
        ? `{${x2}, ${y2}} to {0, 0} is valid`
        : `{${x2}, ${y2}} to {0, 0} is invalid`);

    console.log(Number.isInteger(distance3)
        ? `{${x1}, ${y1}} to {${x2}, ${y2}} is valid`
        : `{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
}

pointsValidation([3, 0, 0, 4]);
// {3, 0} to {0, 0} is valid
// {0, 4} to {0, 0} is valid
// {3, 0} to {0, 4} is valid
pointsValidation([2, 1, 1, 1]);
// {2, 1} to {0, 0} is invalid
// {1, 1} to {0, 0} is invalid
// {2, 1} to {1, 1} is valid