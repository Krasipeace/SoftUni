function roadRadar(speed, area) {
    let limit = 0;
    
    switch (area) {
        case "motorway": 
            limit = 130; 
            break;
        case "interstate": 
            limit = 90; 
            break;
        case "city": 
            limit = 50; 
            break;
        case "residential": 
            limit = 20; 
            break;
    }

    let driverSpeed = speed - limit;

    if (driverSpeed <= 0) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`);
    } else {
        let status = "";

        if (driverSpeed <= 20) {
            status = "speeding";
        } else if (driverSpeed <= 40) {
            status = "excessive speeding";
        } else {
            status = "reckless driving";
        }

        console.log(`The speed is ${driverSpeed} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
}

roadRadar(40, "city"); // Driving 40 km/h in a 50 zone
roadRadar(21, "residential"); // The speed is 1 km/h faster than the allowed speed of 20 - speeding
roadRadar(120, "interstate"); // Excessive speeding
roadRadar(200, "motorway"); // Reckless driving