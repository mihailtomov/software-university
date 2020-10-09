function solve(jsonArr) {
    let employees = [];

    jsonArr.forEach(json => {
        employees.push(JSON.parse(json));
    });

    let html = ['<table>'];

    employees.forEach(employee => {
        html.push('<tr>');
        Object.values(employee).forEach(value => {
            html.push(`<td>${value}</td>`);
        });
        html.push('</tr>');
    });

    html.push('</table>');

    console.log(html.join('\n'));
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}'
]);