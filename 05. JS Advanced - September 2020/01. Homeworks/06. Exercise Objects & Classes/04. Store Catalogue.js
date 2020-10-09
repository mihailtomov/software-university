function solve(data) {
    let result = [];

    data.forEach(row => {
        let [productName, productPrice] = row.split(' : ');
        productPrice = Number(productPrice);
        let product = {name: productName, price: productPrice};
        result.push(product);
    });

    result.sort(((a, b) => a.name.localeCompare(b.name)));
    
    for (let i = 65; i <= 90; i++) {
        let count = 1;

        result.forEach(product => {
            if (product.name.charCodeAt(0) == i) {

                if (count == 1) {
                    console.log(product.name[0]);
                }
                count++;
                console.log(`  ${product.name}: ${product.price}`);
            }
        });     
    }
}

solve(['Banana : 2',
'Rubic\'s Cube : 5',
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10'
]);