function solve(numbers) {
    let result = '';

    for (let i = 0; i < numbers.length; i++) {
        const element = numbers[i];

        if (i % 2 == 0) {
            result += element + ' ';
        }
    }

    console.log(result);
}

solve(['20', '30', '40']);