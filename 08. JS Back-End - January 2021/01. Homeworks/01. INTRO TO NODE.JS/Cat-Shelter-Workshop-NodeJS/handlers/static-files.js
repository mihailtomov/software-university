const fs = require('fs');
const baseUrl = 'http://localhost:3000/';

function getContentType(url) {

    if (url.endsWith('css')) {
        return 'text/css';
    } else if (url.endsWith('html')) {
        return 'text/html';
    } else if (url.endsWith('png')) {
        return 'image/png';
    } else {
        return 'image/ico';
    }
}

module.exports = function (req, res) {
    const { pathname } = new URL(req.url, baseUrl);

    if (pathname.startsWith('/content') && req.method === 'GET') {

        if (pathname.endsWith('png') || pathname.endsWith('jpg') || pathname.endsWith('jpeg') || pathname.endsWith('ico') && req.method === 'GET') {
            
            fs.readFile(`./${pathname}`, function(err, data) {
                if (err) {
                    errorHandler(res, 404, 'text/plain');
                } else {
                    configureHeaders(res, 200, getContentType(`./${pathname}`));
                    res.write(data);
                    res.end();
                }
            });
        } else {
            
            fs.readFile(`./${pathname}`, 'utf8', function(err, data) {
                if (err) {
                    errorHandler(res, 404, 'text/plain');
                } else {
                    configureHeaders(res, 200, getContentType(`./${pathname}`));
                    res.write(data);
                    res.end();
                }
            });
        }
    } else {
        return true;
    }
}

function errorHandler(res, statusCode, type) {
    configureHeaders(res, statusCode, type);
    res.write('An error occured while trying to read the file.');
    res.end();
}

function configureHeaders(res, statusCode, type) {
    res.writeHead(statusCode, {
        'Content-Type': type
    });
}