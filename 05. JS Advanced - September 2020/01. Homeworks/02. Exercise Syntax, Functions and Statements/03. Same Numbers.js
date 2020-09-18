function solve(number) {
    let numberAsString = number.toString();
    let allAreEqual = true;
    let sampleDigit = numberAsString[0];
    let sumOfAllDigits = 0;

    for (let i = 0; i < numberAsString.length; i++) {
        sumOfAllDigits += Number(numberAsString[i]);

        if (numberAsString[i] != sampleDigit) {
            allAreEqual = false;
        }
    }

    if (allAreEqual) {
        console.log('true');
    } else {
        console.log('false');
    }

    console.log(sumOfAllDigits);
}

solve(1234);