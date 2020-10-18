function getArticleGenerator(articles) {
    let articlesArr = articles;
    let contentElement = document.getElementById('content');

    function getCurrentArticle() {
        if (articlesArr.length > 0) {
            let articleElement = document.createElement('article');
            articleElement.textContent = articlesArr.shift();
            contentElement.appendChild(articleElement);
        }
    }

    return getCurrentArticle;
}