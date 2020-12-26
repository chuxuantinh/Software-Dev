function attachEvents() {
    const elements = {
        person() { return document.querySelector('input#person'); },
        phone() { return document.querySelector('input#phone'); },
        createContact() { return document.querySelector('button#btnCreate'); },
        loadContacts() { return document.querySelector('button#btnLoad'); },
        phonebookEl() { return document.querySelector('ul#phonebook'); }
    };
    let phonebook = [];

    function load() {
        elements.phonebookEl().innerHTML = "";
        phonebook.forEach((pb) => {
            let listItem = document.createElement('li');
            const key = Object.keys(pb)[0];
            listItem.textContent = `${pb[key].person}: ${pb[key].phone}`;
            let btn = document.createElement('button');
            btn.textContent = 'Delete';
            btn.value = key;
            btn.addEventListener('click', deleteData);
            listItem.appendChild(btn);
            elements.phonebookEl().appendChild(listItem);
        });
    }


    function deleteData() {
        var pos = phonebook.indexOf(this.value);
        phonebook.splice(pos, 1);
        load();
    }

    const baseURL = 'http://localhost:8000/phonebook/';
    elements.createContact().addEventListener('click', () => {
        const { value: person } = elements.person();
        const { value: phone } = elements.phone();
        fetch(baseURL, {
            method: "POST",
            body: JSON.stringify({ person, phone })
        })
            .then((response) => response.json())
            .then((response) => {
                phonebook.push(response);
                elements.person().value = "";
                elements.phone().value = "";
            });
    });
    elements.loadContacts().addEventListener('click', load); 
}

attachEvents();