function addItem() {
    const itemsList = document.getElementById('items');
    const textInput = document.getElementById('newText');  
    const textInputValue = textInput.value;
    if (!textInputValue) { return; }
    const li = document.createElement('li');
    const a = document.createElement('a');
    a.innerText = '[Delete]';
    a.href = '#';
    a.addEventListener('click', function (e) {
        e.target.parentElement.remove();
    });
    const text = document.createTextNode(textInputValue);
    li.appendChild(text);
    li.appendChild(a);
    
    itemsList.appendChild(li);
    textInput.value = '';
}