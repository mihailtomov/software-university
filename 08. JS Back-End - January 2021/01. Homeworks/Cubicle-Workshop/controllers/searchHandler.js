const fs = require('fs');

module.exports = function (req, res) {

    let { search, from, to } = req.body;

    if (from) {
        from = Number(from);
    }
    if (to) {
        to = Number(to);
    }

    fs.readFile('./config/database.json', 'utf8', (err, data) => {
        if (err) {
            console.log(err);
            return;
        }

        let cubes = JSON.parse(data);

        if (search && !from && !to) {
            // only search

            cubes = cubes.filter(c => c.name.toLowerCase().includes(search.toLowerCase()));
            res.render('index', { cubes });
        } else if (search && from && !to) {
            // search and from

            cubes = cubes.filter(c => c.name.toLowerCase().includes(search.toLowerCase()) && c.difficultyLevel >= from);
            res.render('index', { cubes });

        } else if (search && !from && to) {
            // search and to

            cubes = cubes.filter(c => c.name.toLowerCase().includes(search.toLowerCase()) && c.difficultyLevel <= to);
            res.render('index', { cubes });

        } else if (search && from && to) {
            // all

            cubes = cubes.filter(c => c.name.toLowerCase().includes(search.toLowerCase()) && c.difficultyLevel >= from && c.difficultyLevel <= to);
            res.render('index', { cubes });

        } else if (!search && from && to) {
            // from and to

            cubes = cubes.filter(c => c.difficultyLevel >= from && c.difficultyLevel <= to);
            res.render('index', { cubes });

        } else if (!search && from && !to) {
            // only from

            cubes = cubes.filter(c => c.difficultyLevel >= from);
            res.render('index', { cubes });

        } else if (!search && !from && to) {
            //only to

            cubes = cubes.filter(c => c.difficultyLevel <= to);
            res.render('index', { cubes });

        } else {
            res.redirect('/');
        }
    });
}