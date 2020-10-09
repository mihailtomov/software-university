function solve(data) {
    let juices = [];
    let result = [];

    data.forEach(row => {
        let [juiceName, juiceQuantity] = row.split(' => ');
        juiceQuantity = Number(juiceQuantity);
        
        let juiceObj = {
            name: juiceName,
            quantity: juiceQuantity,
        };

        let juice = juices.find(j => j.name == juiceName);

        if (juices.includes(juice)) {
            juice.quantity += juiceQuantity;
        } else {
            juices.push(juiceObj);
        };

        juices.forEach(juice => {
            if (juice.quantity >= 1000 && !result.some(j => j.name == juice.name)) {
                let obj = {name: juice.name, quantity: 0};
                result.push(obj);
            }
        });
    });

    result.forEach(juice => {
        let bottles = Math.floor(juices.find(j => j.name == juice.name).quantity / 1000);
        juice.quantity = bottles;
        console.log(`${juice.name} => ${juice.quantity}`);
    });
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789'
]);