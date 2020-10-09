function solve(data) {
    let database = {};

    data.forEach(row => {
        let [system, component, subcomponent] = row.split(' | ');

        if (!database[system]) { 
            database[system] = {};
        }
        if (!database[system][component]) {
            database[system][component] = [];
        }

        database[system][component].push(subcomponent);
    });

    Object.entries(database).sort((curr, next) => {
        return Object.entries(next[1]).length - Object.entries(curr[1]).length || 
        curr[0].localeCompare(next[0]);
    }).forEach(([system, components]) => {
        console.log(system);
        Object.entries(components).sort((curr, next) => {
            return next[1].length - curr[1].length;
        }).forEach(([component, subcomponents]) => {
            console.log(`|||${component}`);
            subcomponents.forEach(subcomponent => {
                console.log(`||||||${subcomponent}`);
            });
        });
    });
}

solve(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security'
]); 