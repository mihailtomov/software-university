function solve(data) {
    let speed = data[0];
    let area = data[1];
    let speedLimit;

    switch (area) {
        case 'motorway': speedLimit = 130;
            break;
        case 'interstate': speedLimit = 90;
            break;
        case 'city': speedLimit = 50;
            break;
        case 'residential': speedLimit = 20;
            break;
    }

    if (speed > speedLimit) {
        let overLimit = speed - speedLimit;

        if (overLimit <= 20) {
            console.log('speeding');
        } else if (overLimit <= 40) {
            console.log('excessive speeding');
        } else {
            console.log('reckless driving');
        }
    }
}

solve([200, 'motorway']);