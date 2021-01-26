const fs = require('fs');

module.exports = function (req, res) {

    fs.readFile('./config/database.json', 'utf8', (err, data) => {
        if (err) {
            console.log(err);
            return;
        }
        
        const cubes = JSON.parse(data);

        res.render('index', { cubes });
    });
}