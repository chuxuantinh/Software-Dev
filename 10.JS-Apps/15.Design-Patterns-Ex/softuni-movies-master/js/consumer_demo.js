import Provider from './provider.js';

window.addEventListener('load', () => {
    app();

    function createLabel(provider) {
        const element = document.createElement('p');
        element.textContent = 'Number of tickets: 0';
        const consumer = {
            element,
            onData: (data) => {
                consumer.element.textContent = `Number of tickets: ${data}`;
            }
        };
        provider.subscribe(consumer.onData);
        return consumer;
    }
    
    function app() {
        const provider = new Provider();
        const ticketLabel = createLabel(provider);
        const ticketsSpan = createSpan(provider);
        document.querySelector('main').appendChild(ticketLabel.element);
        document.querySelector('main').appendChild(ticketsSpan.element);
        document.querySelector('#setTickets').addEventListener('click', () => {
            provider.setData(document.querySelector('#tickets').value);
             
        });
    }

    function createSpan(provider) {
        const element = document.createElement('span');
        element.textContent = 'Tickets available: 0';
        const consumer = {
            element,
            onData: (data) => {
                consumer.element.textContent = `Tickets available: ${data}`;
            }
        };
        provider.subscribe(consumer.onData);
        return consumer;
    }
});