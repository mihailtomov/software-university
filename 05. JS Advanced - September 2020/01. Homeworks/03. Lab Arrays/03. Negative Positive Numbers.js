function solve(numbers) {
    let sortedArray = [];

    for (const index in numbers) {

        let currNum = numbers[index];

        if (currNum < 0) {
            sortedArray.unshift(currNum);
        } else {
            sortedArray.push(currNum);
        }
    }

    sortedArray.forEach((x => console.log(x)));
}

solve([3, -2, 0, -1]);