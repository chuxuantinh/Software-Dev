function solve() {
    const addBtn = document.querySelector("body > form > button");
    let [bookInput, yearInput, priceInput] = Array.from(document.querySelectorAll("form > input"));
    const bookShelfOldBooks = document.querySelector("#outputs > section:nth-child(1) > div");
    const bookShelfNewBooks = document.querySelector("#outputs > section:nth-child(2) > div");
    let priceWrapper = document.querySelector("body > h1:nth-child(3)");
    let price = 0;
 
    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        checkForValidInputs();
    });
 
    function checkForValidInputs() {
        let year = Number(yearInput.value);
        let price = Number(priceInput.value);
        let type = '';
        if (bookInput.value !== '' && year > 0 && price > 0) {
            if (year >= 2000) {
                type = 'new';
            } else {
                type = 'old';
            }
            addNewBook(type, year, price);
        }
    }
 
    function addNewBook(type, y, p) {
        let divBook = document.createElement('div');
        divBook.classList.add('book');
 
        let par = document.createElement('p');
        par.textContent = `${bookInput.value} [${y}]`;
 
        let buyBtn = document.createElement('button');
        buyBtn.textContent = `Buy it only for ${p.toFixed(2)} BGN`;
        buyBtn.addEventListener('click',  removeBookAndIcreaseProfit);
 
 
        divBook.appendChild(par);
        divBook.appendChild(buyBtn);
 
        if (type === 'new') {
            let newBooksBtn = document.createElement('button');
            newBooksBtn.textContent = `Move to old section`;
            newBooksBtn.addEventListener('click', () => moveToOldSection(divBook, newBooksBtn, p));
 
            divBook.appendChild(newBooksBtn);
 
            bookShelfNewBooks.appendChild(divBook);
        } else {
            p = p * 0.85;
            buyBtn.textContent = `Buy it only for ${p.toFixed(2)} BGN`;
            bookShelfOldBooks.appendChild(divBook);
 
        }
 
    }
 
    function removeBookAndIcreaseProfit(e) {
        //Matching the current price
        let pr = Number(e.target.innerHTML.match(/\d+\.\d+/g).join(''));
        price += pr;
        priceWrapper.textContent = `Total Store Profit: ${+price.toFixed(2)} BGN`;
        //Removing a div from ANY bookshelf
        let parent = e.target.parentNode.parentNode;
        let index = findElIndex(Array.from(parent.children), e.target.parentNode);
        removeEl(parent, index);
 
    }
    //Finding the index of the correct div child
    function findElIndex(parent, child) {
        return parent.findIndex((e) => e === child);
    }
    //Removing a child from the parent div at the given index
    function removeEl(parent, index) {
        parent.removeChild(parent.children[index]);
    }
 
    function moveToOldSection(child, btnToRemove, p) {
        //Decreasing the price when moved to old section
        p = p * 0.85;
        bookShelfNewBooks.removeChild(child);
        child.removeChild(btnToRemove);
        bookShelfOldBooks.appendChild(child);
        child.lastChild.innerHTML = `Buy it only for ${p.toFixed(2)} BGN`;
    }
}