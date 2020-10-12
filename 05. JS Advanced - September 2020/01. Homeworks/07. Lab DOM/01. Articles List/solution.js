function createArticle() {
	let inputElement = document.getElementById('createTitle');
	let textAreaElement = document.getElementById('createContent');
	let articlesElement = document.getElementById('articles');

	let newArticleElement = document.createElement('article');
	let newHeadingElement = document.createElement('h3');
	let newParagraphElement = document.createElement('p');

	if (inputElement.value != null && textAreaElement != null) {
		newHeadingElement.innerHTML = inputElement.value;
		newParagraphElement.innerHTML = textAreaElement.value;

		newArticleElement.appendChild(newHeadingElement);
		newArticleElement.appendChild(newParagraphElement);
		articlesElement.appendChild(newArticleElement);

		inputElement.value = '';
		textAreaElement.value = '';
	}
}