function solve(data, sortCriteria) {
    let result = [];

    data.forEach(row => {
        let [destination, price, status] = row.split('|');
        price = Number(price);
        result.push({ destination, price, status });
    });

    switch (sortCriteria) {
        case 'destination':
            result.sort((a, b) => a.destination.localeCompare(b.destination));
            break;
        case 'price':
            result.sort((a, b) => a.price - b.price);
            break;
        default:
            result.sort((a, b) => a.status.localeCompare(b.status));
            break;
    };

    return result;
}

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status'
)