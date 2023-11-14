function getMeetings(input) {
    let schedule = {};

    for (let line of input) {
        let [day, name] = line.split(' ');

        if (schedule.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
        } else {
            schedule[day] = name;
            console.log(`Scheduled for ${day}`);
        }
    }

    for (let day in schedule) {
        console.log(`${day} -> ${schedule[day]}`);
    }
}

getMeetings(['Monday Peter', 'Wednesday Bill', 'Monday Tim', 'Friday Tim']);
// Scheduled for Monday
// Scheduled for Wednesday
// Conflict on Monday!
// Scheduled for Friday
// Monday -> Peter
// Wednesday -> Bill
// Friday -> Tim