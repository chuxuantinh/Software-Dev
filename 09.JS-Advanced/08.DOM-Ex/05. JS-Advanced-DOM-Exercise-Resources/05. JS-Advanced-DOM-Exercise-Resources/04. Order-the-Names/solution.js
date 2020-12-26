function solve() {
    document.querySelector('button').addEventListener('click', onClick);
    const list = {};
    const items = document.querySelectorAll('ol').querySelectorAll('li');
    [...items].forEach(e => {
        if (e.textContent.trim().length === 0) {
            return;
        }
        const letter = e.textContent[0].toLocaleUpperCase();
        list[letter] = e.textContent;
    });

    function onClick() {
        const input = document.querySelector('input');
        const value = input.value;
        const letter = value[0].toLocaleUpperCase();
        if (list.hasOwnProperty(letter) === false) {
            list[letter] = value;
        } else {
            list[letter] = list[letter] + ', ' + value;
        }
        const index = letter.charCodeAt(0) - 65;
        items[index].textContent = list[letter];

        input.value = '';
    }
}

//2
function solve() {
    let database = {
        A: [],
        B: [],
        C: [],
        D: [],
        E: [],
        F: [],
        G: [],
        H: [],
        I: [],
        J: [],
        K: [],
        L: [],
        M: [],
        N: ['Nixon'],
        O: [],
        P: ['Peterson'],
        Q: [],
        R: [],
        S: [],
        T: [],
        U: [],
        V: [],
        W: [],
        X: [],
        Y: [],
        Z: []
    } 
    document.querySelector("#exercise > article > button").addEventListener('click', main);
    function main() {
        let name = document
            .querySelector("#exercise > article > input[type=text]")
            .value;
        if (name === '') {
            return '';
        }
        name = addName(name);
        updateInfo(name);
    }
    function addName(name) {
        name = name.substring(0, 1).toUpperCase() +
        name.substring(1).toLowerCase();
        database[name[0]].push(name);
        return name;
    }
    function updateInfo(name) {
        let rows = document.querySelectorAll("ol li");
        let index = name.charCodeAt(0) - 65;
        rows[index].textContent = database[name[0]].join(', ');
    }
}