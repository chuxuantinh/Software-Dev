function deleteByEmail() {
    const emailTds = Array.from(document.querySelectorAll('#customers td:last-child'));
    const emailInput = document.querySelector('input[name="email"]');
    const resultDiv = document.getElementById('result');

    resultDiv.innerText = '';

    const emailInputValue = emailInput.value;
    if (!emailInputValue) { return; }
    const td = emailTds.find(function (td) { return td.innerText === emailInputValue });
    emailInput.value = '';
    if (!td) { resultDiv.innerText = 'Not found.'; return; }
    td.parentElement.remove();
    resultDiv.innerText = 'Deleted.';
}