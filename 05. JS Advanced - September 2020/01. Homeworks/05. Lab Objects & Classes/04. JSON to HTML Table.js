function solve(input) {
    let data = JSON.parse(input);

    let result = '<table>\n<tr>';

    let keys = Object.keys(data[0]);
    
    function escapeHtml(unsafe) {
        return unsafe
             .replace(/&/g, "&amp;")
             .replace(/</g, "&lt;")
             .replace(/>/g, "&gt;")
             .replace(/"/g, "&quot;")
             .replace(/'/g, "&#039;");
     };

    keys.forEach(key => {
        result += '<th>';
        result += escapeHtml(`${key}`);
        result += '</th>';
    });

    result += '</tr>\n<tr>';

    data.forEach(obj => {
        let values = Object.values(obj);

        values.forEach(value => {
            result += '<td>';
            result += escapeHtml(`${value}`);
            result += '</td>';
        });

        if (data[data.length - 1] != obj) {
            result += '</tr>\n<tr>';
        } else {
            result += '</tr>\n</table>';
        }      
    });

    console.log(result);
}

solve(['[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]']);