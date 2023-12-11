function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/blog/';
    const loadPostsBtn = document.getElementById('btnLoadPosts');
    const postsSelect = document.getElementById('posts');
    const viewBtn = document.getElementById('btnViewPost');
    const postTitle = document.getElementById('post-title');
    const postBody = document.getElementById('post-body');
    const postComments = document.getElementById('post-comments');
    let allPosts = {};

    loadPostsBtn.addEventListener('click', async () => {
        postsSelect.innerHTML = '';
        const response = await fetch(baseUrl + 'posts');

        allPosts = await response.json();

        for (const [postId, postObj] of Object.entries(allPosts)) {
            const option = document.createElement('option');
            option.value = postId;
            option.textContent = postObj.title;
            postsSelect.appendChild(option);
        }
    });

    viewBtn.addEventListener('click', async () => {
        const postId = postsSelect.value;

        postComments.innerHTML = '';
        postBody.innerHTML = '';

        postTitle.textContent = allPosts[postId].title;
        postBody.textContent = allPosts[postId].body;

        const response = await fetch(baseUrl + 'comments');
        const commentsInfo = await response.json();
        const filteredComments = Object.values(commentsInfo).filter(c => c.postId === postId);

        filteredComments.forEach(c => {
            const li = document.createElement('li');
            li.Id = c.Id;
            li.textContent = c.text;
            postComments.appendChild(li);
        });
    });
}

attachEvents();