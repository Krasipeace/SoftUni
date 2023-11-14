function getFlightSchedule(input) {
    let flights = {};
    let flightStatus = {};
    let status = input[2][0];

    function processFlights(input) {
        for (let line of input) {
            let [flight, destination] = line.split(' ');
            flights[flight] = destination;
            flightStatus[flight] = 'Ready to fly';
        }
    }

    function updateFlightStatus(input) {
        for (let line of input) {
            let [flight, status] = line.split(' ');
            flightStatus[flight] = status;
        }
    }

    function printFlights(status) {
        let result = Object.keys(flights).filter(f => flightStatus[f] === status);

        for (let flight of result) {
            console.log({ Destination: flights[flight], Status: flightStatus[flight] });
        }
    }

    processFlights(input[0]);
    updateFlightStatus(input[1]);
    printFlights(status);
}

getFlightSchedule([
    ['WN269 Delaware',
        'FL2269 Oregon',
        'WN498 Las Vegas',
        'WN3145 Ohio',
        'WN612 Alabama',
        'WN4010 New York',
        'WN1173 California',
        'DL2120 Texas',
        'KL5744 Illinois',
        'WN678 Pennsylvania'],
    ['DL2120 Cancelled',
        'WN612 Cancelled',
        'WN1173 Cancelled',
        'SK430 Cancelled'],
    ['Cancelled']
]);
// { Destination: 'Alabama', Status: 'Cancelled' }
// { Destination: 'California', Status: 'Cancelled' }
// { Destination: 'Texas', Status: 'Cancelled' }