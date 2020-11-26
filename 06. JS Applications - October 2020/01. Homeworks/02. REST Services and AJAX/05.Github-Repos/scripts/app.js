function loadRepos() {
	const usernameInput = document.getElementById('username');
	const url = `https://api.github.com/users/${usernameInput.value}/repos`;
	const ulList = document.getElementById('repos');
	ulList.innerHTML = '';

	fetch(url)
	.then(response => response.status < 400 ? response.json() : ulList.innerHTML = `<li>${response.statusText}</li>`)
	.then(data =>  {
		if (data != '<li>Not Found</li>') {
			data.forEach(repo => ulList.innerHTML += `<li><a href="${repo.html_url}">${repo.full_name}</a></li>`);
		}
	});
}