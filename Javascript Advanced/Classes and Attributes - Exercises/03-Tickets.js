function tickets(input, status) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    let tickets = [];

    for (let line of input) {
        let [destination, price, status] = line.split('|');
        tickets.push(new Ticket(destination, price, status));
    }

    return tickets.sort((a, b) => {
        if (typeof a[status] === 'string') {
            return a[status].localeCompare(b[status]);
        } else {
            return a[status] - b[status];
        }
    });
}

console.log(tickets(['Philadelphia|94.20|available', 'New York City|95.99|available', 'New York City|95.99|sold', 'Boston|126.20|departed'], 'destination')); // [ Ticket { destination: 'Boston', price: 126.2, status: 'departed' }, Ticket { destination: 'New York City', price: 95.99, status: 'available' }, Ticket { destination: 'New York City', price: 95.99, status: 'sold' }, Ticket { destination: 'Philadelphia', price: 94.2, status: 'available' } ]