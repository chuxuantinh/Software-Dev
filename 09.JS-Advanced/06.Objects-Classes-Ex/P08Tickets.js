function solve(tickets, criteria) {
    class Ticket {
        constructor(descriptor) {
            const [destination, price, status] = descriptor.split('|');
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    const comparator = {
        destination: (a, b) => a.destination.localeCompare(b.destination),
        price: (a, b) => a - b,
        status: (a, b) => a.status.localeCompare(b.status)
    };

    return tickets.map(t => new Ticket(t)).sort(comparator[criteria]);
}

//2
function solve(tickets, criteria) {
    class Ticket {
        constructor(descriptor) {
            const [destination, price, status] = descriptor.split('|');
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    return tickets.map(t => new Ticket(t)).sort(comparator);

    function comparator(a, b) {
        try {
            return a[criteria].localeCompare(b[criteria]);
        } catch (e) {
            return a[criteria] - b[criteria];
        }
    }
}