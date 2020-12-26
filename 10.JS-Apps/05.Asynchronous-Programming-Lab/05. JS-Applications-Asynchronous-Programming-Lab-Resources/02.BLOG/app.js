// Not working
const loadPostsBtn = document.getElementById('btnLoadPosts');
const postsSelectEl = document.getElementById('posts');
const viewPostsBtn = document.getElementById('btnViewPost');
const postTitleEl = document.getElementById('post-title');
const postBodyEl = document.getElementById('post-body');
const postCommentsUlEl = document.getElementById('post-comments');
const baseUrl = 'https://blog-apps-c12bf.firebaseio.com/';

function loadPosts() {
    postsSelectEl.innerHTML = '<option value="" disabled selected>Select post...</option>';
    fetch(`${baseUrl}/posts.json`).then(res => res.json()).then(posts => {
        Object.entries(posts).forEach(([key, value]) => {
            const o = document.createElement('option');
            o.value = key;
            o.textContent = value.title;
            postsSelectEl.appendChild(o);
        });
    });
}

function loadPostComments() {
    const postId = postsSelectEl.value;
    const commentsReq = fetch(`${baseUrl}/comments.json`).then(res => res.json());
    const postReq = fetch(`${baseUrl}/posts/${postId}.json`).then(res => res.json());
    Promise.all([commentsReq, postReq]).then(([comments, currentPost]) => {
        // const allPostComments = Object.entries(comments).reduce((acc, [key, value]) => {
        //     if (!Object.keys(currentPost.comments || {}).map(x => x.postId).includes(postId)) { return acc; }
        //     return acc.concat(value);
        // }, []);
        postTitleEl.textContent = currentPost.title;
        postBodyEl.textContent = currentPost.body;
        postCommentsUlEl.innerHTML = '';
        Object.entries(currentPost.comments || {}).forEach(([key, value]) => {
            const li = document.createElement('li');
            li.textContent = value.text;
            postCommentsUlEl.appendChild(li);
        });
    });
}

function attachEvents() {
    loadPostsBtn.addEventListener('click', loadPosts);
    viewPostsBtn.addEventListener('click', loadPostComments);
}

attachEvents();