const fs = require('fs');
const data = require('../config/database.json');

let id = data.length > 0 ? data.length + 1 : 1;

module.exports = function (req, res) {
    const { name, description, imageUrl, difficultyLevel } = req.body;

    if (name && description && imageUrl && difficultyLevel) {
        req.body.id = id;
    
        data.push(req.body);
    
        fs.writeFile('config/database.json', JSON.stringify(data), err => {
            if (err) {
                console.log(err);
                return;
            }
    
            console.log('New entry added successfully.');
            id++;
        });
    
        res.redirect('/');
    } else {
        res.redirect('/create');
    }
}