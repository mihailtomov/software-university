function solve(numbers) {

    let oddNumbers = numbers
        .filter((x, i) => i % 2 != 0)
        .map(x => x * 2)
        .reverse();

    console.log(oddNumbers.join(' '));
}

solve([10, 15, 20, 25]);