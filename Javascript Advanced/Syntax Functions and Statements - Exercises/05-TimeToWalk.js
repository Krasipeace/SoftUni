function timeToWalk(steps, meters, speed) {
    let distance = steps * meters;
    let time = Math.round(distance / speed * (3600 / 1000));
    let rest = Math.floor(distance / 500);
    let hours = Math.floor(time / 3600);
    let minutes = Math.floor((time - (hours * 3600)) / 60);
    let seconds = time % 60;

    console.log(
        (hours < 10 ? "0" : "") + hours + 
            ":" + (minutes + rest < 10 ? "0" : "") + (minutes + rest) + 
                ":" + (seconds < 10 ? "0" : "") + seconds);
}

timeToWalk(4000, 0.60, 5); // 00:32:48
timeToWalk(2564, 0.70, 5.5); // 00:22:35