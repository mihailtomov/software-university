function solve(input) {
    let data = JSON.parse(input);
    let result = ['<table>'];
    let keys = Object.keys(data[0]);
    let keysHTML = '<tr>';

    keys.forEach(key => {
        keysHTML += `<th>${key}</th>`
    });

    keysHTML += '</tr>'

    result.push(keysHTML);

    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
     };

    data.forEach(obj => {
        let values = Object.values(obj);

        let valuesHTML = '<tr>';          
        values.forEach(value => {
            value = escapeHtml(`${value}`);
            valuesHTML += `<td>${value}</td>`;
        });
        valuesHTML += '</tr>';

        result.push(valuesHTML);
    });

    result.push('</table>')

    return result.join('\n');
}

solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']);