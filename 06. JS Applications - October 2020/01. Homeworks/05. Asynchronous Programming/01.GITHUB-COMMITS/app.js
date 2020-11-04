function loadCommits() {
    let username = document.querySelector('#username').value;
    let repository = document.querySelector('#repo').value;

    let commits = document.querySelector('#commits');

    const url = `https://api.github.com/repos/${username}/${repository}/commits`;

    fetch(url)
        .then(response => {
            if (response.status < 400) {
                return response.json();
            } else {
                return Promise.reject(`<li>Error: ${response.status} (${response.statusText})</li>`);
            } 
        })
        .then(commitsArray => {
            let output = commitsArray
                .map(c => `<li>${c.commit.author.name}: ${c.commit.message}</li>`)
                .join('');

            commits.innerHTML = output;
        })
        .catch(err => {
            commits.innerHTML = err;
        });
}