const appId = 'CC824F11-EE52-8180-FF9E-B650BA3FD900';
const apiKey = 'ECC7CE98-ECC1-4EA4-BCF0-9C6409675AF9';

const baseUrl = `https://api.backendless.com/${appId}/${apiKey}/data/students`;

function makeHeaders(method, data) {
    const headers = {
        method: method,
        headers: {
            'Content-Type': 'application/json'
        }
    }
    if (method === 'PUT' || method === 'POST') {
        headers.body = JSON.stringify(data);
    }
    return headers;
}
async function get() {
    const headers = makeHeaders('GET');
    const data = await fetchRequest(baseUrl, headers);
    return data;
}
async function post(body) {
    const headers = makeHeaders('POST', body);
    const data = fetchRequest(baseUrl, headers);
    return data;
}
async function put(body, bookID) {
    const headers = makeHeaders('PUT', body);
    const url = `${baseUrl}/${bookID}`;
    return fetchRequest(url, headers);
}
async function del(bookID) {
    const headers = makeHeaders('DELETE');
    const url = `${baseUrl}/${bookID}`;
    return fetchRequest(url, headers);
}
async function fetchRequest(url, headers) {
    return fetch(url, headers)
        .then(checkForErrors)
        .then(data => data.json())
        .catch(console.error)
}
function checkForErrors(req) {
    if (!req.ok) {
        throw new Error(`${req.status} - ${req.statusText}`);
    }
    return req;
}
export { get, post, put, del }