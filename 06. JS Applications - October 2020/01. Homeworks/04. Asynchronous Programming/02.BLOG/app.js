function attachEvents() {
    let loadPostsBtn = document.getElementById('btnLoadPosts');
    let viewPostBtn = document.getElementById('btnViewPost');
    let dropdownList = document.getElementById('posts');

    const baseUrl = `https://blog-apps-c12bf.firebaseio.com`;

    loadPostsBtn.addEventListener('click', onLoadPostsClick);

    function onLoadPostsClick() {
        const postsUrl = baseUrl + '/posts.json';

        fetch(postsUrl)
            .then(response => response.json())
            .then(posts => {
                Object.entries(posts).forEach(([key, post]) => {
                    dropdownList.innerHTML += `<option value="${key}">${post.title}</option>`;
                });
            });
    }

    viewPostBtn.addEventListener('click', onViewPostClick);

    function onViewPostClick() {
        selectedPost = Array.from(dropdownList.children).find(p => p.selected);
        let key = selectedPost.value;
        
        const selectedPostUrl = baseUrl + `/posts/${key}.json`;
        const commentsUrl = selectedPostUrl.substring(0, selectedPostUrl.length - 5) + `/comments.json`;

        (async function getSelectedPostInfo() {
            let selectedPostResponse = await fetch(selectedPostUrl);
            let commentsResponse = await fetch(commentsUrl);

            let selectedPost = await selectedPostResponse.json();
            let comments = await commentsResponse.json();

            let postTitle = document.getElementById('post-title');
            let postBody = document.getElementById('post-body');

            let postCommentsUl = document.getElementById('post-comments');
            postCommentsUl.innerHTML = '';

            postTitle.textContent = selectedPost.title
            postBody.textContent = selectedPost.body;

            postCommentsUl.innerHTML = comments.map(x => `<li>${x.text}</li>`).join('');
        })();
    }
}

attachEvents();