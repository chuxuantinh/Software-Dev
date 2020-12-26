window.addEventListener('load', () => {
    document.querySelector('#btnLoadTowns').addEventListener('click', renderTowns);
    const input = document.querySelector('#towns');
    const rootEl = document.querySelector('#root');
    const templateString = document.getElementById('main-template').innerHTML;
    const templateFn = Handlebars.compile(templateString);

    function renderTowns(e) {
        e.preventDefault();
        const towns = input.value.split(', ');
        const generatedHtml = templateFn({ towns });
        rootEl.innerHTML = generatedHtml;
    }
});