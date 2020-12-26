function attachEvents() {
    const sendBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');
    const inputName = document.getElementById('author');
    const inputMessage = document.getElementById('content');
    const textarea = document.getElementById('messages');

    sendBtn.addEventListener('click', sendMessage);
    refreshBtn.addEventListener('click', showMessages);

    const messages = [];
    const baseURL = `http://localhost:8000/messenger`;

    function sendMessage() {
        const headers = {
            method: 'POST',
            headers: { 'Content-type': 'application/json' },
            body: JSON.stringify({
                author: inputName.value,
                content: inputMessage.value
            })
        }
        fetch(baseURL, headers)
            .then((response) => response.json())
            .then((response) => {
                messages.push(response);
                inputName.value = "";
                inputMessage.value = "";
            });
            
    }
    function showMessages() {
        fetch(baseURL)
            .then(res => res.json())
            .then(data => {
                textarea.value = '';
                Object.values(data)
                    .forEach(({ author, content }) => {
                        textarea.value += `${author}: ${content}\n`;
                    });
            });
    }
}

attachEvents();