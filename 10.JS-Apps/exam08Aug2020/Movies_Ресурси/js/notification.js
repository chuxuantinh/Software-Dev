const elements = {
    info: document.querySelector('#successBox'),
    errorNotification: document.querySelectorAll('.notifications')[0],
    error: document.querySelector('#errorBox'),
    infoNotification: document.querySelectorAll('.notifications')[1]
    // loading: document.querySelector('#loadingBox')
};

elements.info.addEventListener('click', hideInfo);
elements.error.addEventListener('click', hideError);

export function showInfo(message) {
    elements.info.textContent = message;
    elements.infoNotification.style.display = 'block';

    setTimeout(hideInfo, 1000);
}

export function showError(message) {
    elements.error.textContent = message;
    elements.errorNotification.style.display = 'block';

    setTimeout(hideError, 1000);
}

let requests = 0;

export function beginRequest() {
    requests++;
    elements.loading.style.display = 'block';
}

export function endRequest() {
    requests--;
    if (requests === 0) {
        elements.loading.style.display = 'none';
    }
}

function hideInfo() {
    elements.infoNotification.style.display = 'none';
}

function hideError() {
    elements.errorNotification.style.display = 'none';
}