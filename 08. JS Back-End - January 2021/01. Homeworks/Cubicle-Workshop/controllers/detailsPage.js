const fs = require('fs');

module.exports = function (req, res) {
    const id = Number(req.params.id);

    fs.readFile('./config/database.json', 'utf8', (err, data) => {
        if (err) {
            console.log(err);
            return;
        }
        
        const cubes = JSON.parse(data);
        const searchedCube = cubes.find(c => c.id === id);

        res.render('details', searchedCube);
    });
}