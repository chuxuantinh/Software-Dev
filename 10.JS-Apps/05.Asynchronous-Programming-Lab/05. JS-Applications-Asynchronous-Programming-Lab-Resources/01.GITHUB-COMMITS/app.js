const usernameEl = document.getElementById('username');
const repoEl = document.getElementById('repo');
const commitsUlEl = document.getElementById('commits');

function getUrl(username, repo) {
    return `https://api.github.com/repos/${username}/${repo}/commits`;
}
function loadCommits() {
    // Try it with Fetch API
    commitsUlEl.innerHTML = '';
    const username = usernameEl.value;
    const repo = repoEl.value;
    const url = getUrl(username, repo);
    fetch(url).then(res => {
        if (res.ok === false) {
            const li = document.createElement('li');
            li.textContent = `Error: ${res.status} (${res.statusText})`;
            commitsUlEl.appendChild(li);
            return;
        }
        res.json().then(data => {
            data.forEach(item => {
                const li = document.createElement('li');
                li.textContent = `${item.commit.author.name} ${item.commit.message}`;
                commitsUlEl.appendChild(li);
            });
        });
    });
}