function createArticle() {
	const articlesSection = document.querySelector('#articles');
	const titleInput = document.querySelector('#createTitle');
	const contentInput = document.querySelector('#createContent');

	if (titleInput.value.trim() && contentInput.value.trim()) {
		const article = document.createElement('article');
		const h3 = document.createElement('h3');
		const p = document.createElement('p');

		h3.innerHTML = titleInput.value;
		p.innerHTML = contentInput.value;

		article.appendChild(h3);
		article.appendChild(p);

		articlesSection.appendChild(article);
	}

	titleInput.value = '';
	contentInput.value = '';
}