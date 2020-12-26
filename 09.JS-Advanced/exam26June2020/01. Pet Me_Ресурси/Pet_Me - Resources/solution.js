function solve() {
    const input = document.querySelector('#container').children;
    const inputName = input[0];
    const inputAge = input[1];
    const inputKind = input[2];
    const inputCurrentOwner = input[3];
    const addBtn = input[4];
    const ulInSectionAdoption = document.querySelector('#adoption > ul');
    const ulInSectionAdopted = document.querySelector('#adopted > ul');

    addBtn.addEventListener('click', adoption);

    function adoption(e) {
        e.preventDefault();
        const name = inputName.value;
        const age = Number(inputAge.value);
        const kind = inputKind.value;
        const currentOwner = inputCurrentOwner.value;

        if (name.length > 0 && !isNaN(age) && kind.length > 0 && currentOwner.length > 0) {
            const contactBtn = el('button', 'Contact with owner');
            const pet = el('li', [
                el('p', [
                    el('strong', `${name}`),
                    ' is a ',
                    el('strong', `${age}`),
                    ' year old ',
                    el('strong', `${kind}`)
                ]),
                el('span', `Owner: ${currentOwner}`),
                contactBtn
            ]);
            ulInSectionAdoption.appendChild(pet);
            contactBtn.addEventListener('click', yes);

            function yes(e) {
                contactBtn.remove();
                
                const yes = '<button>Yes! I take it!</button>';
                pet.innerHTML += '<div>';
                pet.innerHTML += '</div>';
                const petDiv = pet.querySelector('div');
                petDiv.innerHTML += '<input placeholder="Enter your names">';
                petDiv.innerHTML += yes; 
                const yesBtn = pet.querySelector('button');
                yesBtn.addEventListener('click', move);

                function move() {
                    const adopterName = pet.querySelector('input').value;
                    if(adopterName.length > 0) {
                        pet.querySelector('span').textContent = `New Owner: ${adopterName}`;
                        pet.querySelector('div').remove();
                        pet.innerHTML += '<button>Checked</button>';
                        ulInSectionAdopted.appendChild(pet);
                        const checkBtn = pet.querySelector('button');
                        checkBtn.addEventListener('click', deletePet);

                        function deletePet() {
                            pet.remove();
                        }
                    }
                }
            }
        }

        

        inputName.value = '';
        inputAge.value = '';
        inputKind.value = '';
        inputCurrentOwner.value = '';
    }

    function el(type, content, attributes) {
        const result = document.createElement(type);
        if (attributes !== undefined) {
            // Object.keys(attributes).forEach(k => {
            //    result[k] = attributes[k];
            // });
            Object.assign(result, attributes);
        }
        if (Array.isArray(content)) {
            content.forEach(append);
        } else {
            append(content);
        }
        function append(node) {
            if (typeof node === 'string' || typeof node === 'number') {
                node = document.createTextNode(node);
            }
            result.appendChild(node);
        }
        return result;
    }
}

