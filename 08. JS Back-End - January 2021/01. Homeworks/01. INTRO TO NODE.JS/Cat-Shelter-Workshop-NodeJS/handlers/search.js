const fs = require('fs');
const path = require('path');
const formidable = require('formidable');
const cats = require('../data/cats');
const baseUrl = 'http://localhost:3000/';

module.exports = function (req, res) {
    const { pathname } = new URL(req.url, baseUrl);

    if (pathname === '/search' && req.method === 'POST') {
        let form = new formidable.IncomingForm();

        form.parse(req, function (err, field) {
            let { searchText } = field;
            searchText = searchText.toLowerCase();

            let filteredCats = [];

            cats.forEach(c => {
                if (
                c.name.toLowerCase().includes(searchText) || 
                c.description.toLowerCase().includes(searchText) || 
                c.breed.toLowerCase().includes(searchText)
                ) {
                    filteredCats.push(c);
                }
            });

            const filePath = './views/home/index.html';

            fs.readFile(filePath, (err, data) => {
                if (err) {
                    configureHeaders(res, 404, 'plain');
                    res.write('An error occured while trying to read the file.');
                } else {
                    configureHeaders(res, 200, 'html');

                    let modifiedCats = filteredCats.map(cat => `<li>
					<img src="${path.join('./content/images/' + cat.image)}" alt="${cat.name}">
					<h3>${cat.name}</h3>
					<p><span>Breed: </span>${cat.breed}</p>
					<p><span>Description: </span>${cat.description}</p>
					<ul class="buttons">
						<li class="btn edit"><a href="/cats-edit/${cat.id}">Change Info</a></li>
						<li class="btn delete"><a href="/cats-find-new-home/${cat.id}">New Home</a></li>
					</ul>
                </li>`);

                    let modifiedData = data.toString().replace('{{cats}}', modifiedCats);

                    res.write(modifiedData);
                    res.end();
                }
            })
        });
    }
}

function configureHeaders(res, statusCode, type) {
    res.writeHead(statusCode, {
        'Content-Type': `text/${type}`
    });
}