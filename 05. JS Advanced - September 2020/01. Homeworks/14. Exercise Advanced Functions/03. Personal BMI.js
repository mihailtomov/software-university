function solve(name, age, weight, height) {
    let bodyMassIndex = Math.round(weight / ((height / 100) ** 2));

    let getStatus = function () {
        if (bodyMassIndex < 18.5) {
            return 'underweight';
        } else if (bodyMassIndex >= 18.5 && bodyMassIndex < 25) {
            return 'normal';
        } else if (bodyMassIndex >= 25 && bodyMassIndex < 30) {
            return 'overweight';
        } else {
            return 'obese';
        }
    }

    let patientChart = {
        name,
        personalInfo: { age, weight, height },
        BMI: bodyMassIndex,
        status: getStatus(),
    }

    if (patientChart.status == 'obese') {
        patientChart.recommendation = 'admission required';
    }

    return patientChart;
}

console.log(solve('Honey Boo Boo', 9, 57, 137));

console.log();