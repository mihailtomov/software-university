const fs = require('fs');
const path = require('path');
const formidable = require('formidable');
const breeds = require('../data/breeds');
const cats = require('../data/cats');
const baseUrl = 'http://localhost:3000/';
let id = 1;

cats[cats.length - 1] ? id = cats[cats.length - 1].id + 1 : id = 1;

module.exports = function (req, res) {

    const { pathname } = new URL(req.url, baseUrl);

    if (pathname === '/cats/add-cat' && req.method === 'GET') {
        const filePath = './views/addCat.html';
        fs.readFile(filePath, (err, data) => {
            if (err) {
                errorHandler(res, 404, 'plain');
            } else {
                configureHeaders(res, 200, 'html');
                let catBreedPlaceholder = breeds.map(breed => `<option value="${breed}">${breed}</option>`);
                let modifiedData = data.toString().replace('{{catBreeds}}', catBreedPlaceholder);
                res.write(modifiedData);
                res.end();
            }
        });
    } else if (pathname === '/cats/add-breed' && req.method === 'GET') {
        const filePath = './views/addBreed.html';
        fs.readFile(filePath, (err, data) => {
            if (err) {
                errorHandler(res, 404, 'plain');
            } else {
                configureHeaders(res, 200, 'html');
                res.write(data);
                res.end();
            }
        });
    } else if (pathname === '/cats/add-breed' && req.method === 'POST') {
        let form = new formidable.IncomingForm();

        form.parse(req, function (err, field) {
            if (err) {
                errorHandler(res, 404, 'plain');
            }

            const { breed } = field;

            fs.readFile('./data/breeds.json', (err, data) => {
                if (err) {
                    errorHandler(res, 404, 'plain');
                } else {
                    breeds.push(breed);
                    fs.writeFile('./data/breeds.json', JSON.stringify(breeds), err => {
                        if (err) {
                            errorHandler(res, 404, 'plain');
                        }
                        redirect(res, '/');
                    });
                }
            });
        });
    } else if (pathname === '/cats/add-cat' && req.method === 'POST') {
        let form = new formidable.IncomingForm();

        form.parse(req, function (err, fields, file) {
            if (err) {
                errorHandler(res, 404, 'plain');
            }

            const { upload: { name: fileName } } = file;

            fs.rename(file.upload.path, `./content/images/${fileName}`, (err) => {
                if (err) {
                    errorHandler(res, 404, 'plain');
                }
            });

            const { name, description, breed } = fields;

            let catObj = { id, name, description, breed, image: fileName };
            id++;

            fs.readFile('./data/cats.json', (err, data) => {
                if (err) {
                    errorHandler(res, 404, 'plain');
                } else {
                    cats.push(catObj);
                    fs.writeFile('./data/cats.json', JSON.stringify(cats), err => {
                        if (err) {
                            errorHandler(res, 404, 'plain');
                        }
                        redirect(res, '/');
                    });
                }
            });
        });
    } else if (pathname.includes('/cats-edit') && req.method === 'GET') {
        const id = Number(pathname.split('/')[2]);
        const catObj = cats.find(c => c.id === id);
        const filePath = './views/editCat.html';

        fs.readFile(filePath, (err, data) => {
            if (err) {
                errorHandler(res, 404, 'plain');
            } else {
                configureHeaders(res, 200, 'html');
                let modifiedData = data.toString().replace('{{id}}', id);
                modifiedData = modifiedData.replace('{{name}}', catObj.name);
                modifiedData = modifiedData.replace('{{description}}', catObj.description);

                const breedAsOptions = breeds.map(b => `<option value="${b}">${b}</option>`);
                modifiedData = modifiedData.replace('{{catBreeds}}', breedAsOptions.join('/'));

                res.write(modifiedData);
                res.end();
            }
        });
    } else if (pathname.includes('/cats-find-new-home') && req.method === 'GET') {
        if (pathname.split('/')[2] !== 'content') {
            const id = Number(pathname.split('/')[2]);
            const catObj = cats.find(c => c.id === id);
            const filePath = './views/catShelter.html';

            fs.readFile(filePath, (err, data) => {
                if (err) {
                    errorHandler(res, 404, 'plain');
                } else {
                    configureHeaders(res, 200, 'html');
                    let modifiedData = data.toString().replace('{{id}}', id);

                    modifiedData = modifiedData.replace(/{{name}}/g, catObj.name);
                    modifiedData = modifiedData.replace('{{description}}', catObj.description);
                    modifiedData = modifiedData.replace(/{{breed}}/g, catObj.breed);
                    modifiedData = modifiedData.replace('{{imgPath}}', `${path.join('./content/images/' + catObj.image)}`);

                    res.write(modifiedData);
                    res.end();
                }
            })
        } else {
            const picName = pathname.split('/')[4];
            fs.readFile(`./content/images/${picName}`, function (err, data) {
                if (err) {
                    errorHandler(res, 404, 'text/plain');
                } else {
                    configureHeaders(res, 200, 'image/png');
                    res.write(data);
                    res.end();
                }
            });
        }
    } else if (pathname.includes('/cats-edit') && req.method === 'POST') {
        let form = new formidable.IncomingForm();
        const id = Number(pathname.split('/')[2]);
        const catObj = cats.find(c => c.id === id);

        form.parse(req, function (err, fields, file) {
            if (err) {
                errorHandler(res, 404, 'plain');
            }

            const { name, description, breed } = fields;
            const { file: { name: fileName } } = file;

            if (name && description && breed && fileName) {
                catObj.name = name;
                catObj.description = description;
                catObj.breed = breed;
                catObj.image = fileName;

                fs.readFile('./data/cats.json', (err, data) => {
                    if (err) {
                        errorHandler(res, 404, 'plain');
                    } else {
                        fs.writeFile('./data/cats.json', JSON.stringify(cats), err => {
                            if (err) {
                                errorHandler(res, 404, 'plain');
                            }
                            redirect(res, '/');
                        });
                    }
                });
            } else {
                redirect(res, pathname);
            }

        });
    } else if (pathname.includes('/cats-find-new-home') && req.method === 'POST') {
        const id = Number(pathname.split('/')[2]);
        const catObj = cats.find(c => c.id === id);
        const index = cats.indexOf(catObj);
        cats.splice(index, 1);

        fs.readFile('./data/cats.json', (err, data) => {
            if (err) {
                errorHandler(res, 404, 'plain');
            } else {
                fs.writeFile('./data/cats.json', JSON.stringify(cats), err => {
                    if (err) {
                        errorHandler(res, 404, 'plain');
                    }
                    redirect(res, '/');
                });
            }
        });
    }
    else {
        return true;
    }
}

function errorHandler(res, statusCode, type) {
    configureHeaders(res, statusCode, type);
    res.write('An error occured while trying to perform an action on the file.');
    res.end();
}

function configureHeaders(res, statusCode, type) {
    res.writeHead(statusCode, {
        'Content-Type': `text/${type}`
    });
}

function redirect(res, path) {
    res.writeHead(301, {
        'Location': path
    });
    res.end();
}