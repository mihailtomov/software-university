function solve(totalSteps, lengthPerStep, speedInKmPerHour) {
    let totalDistanceInMeters = totalSteps * lengthPerStep;
    let speedInMetersPerHour = speedInKmPerHour * 1000;
    let addedMinutes = Math.floor(totalDistanceInMeters / 500);
    let timeNeededInMinutes = ((totalDistanceInMeters / speedInMetersPerHour) * 60) + addedMinutes;
    let hours = Math.floor(timeNeededInMinutes / 60);
    let minutes = Math.floor(timeNeededInMinutes);
    let seconds = (timeNeededInMinutes % minutes) * 60;

    function n(n){
        return n > 9 ? "" + n: "0" + n;
    }

    console.log(`${n(hours)}:${n(minutes)}:${n(seconds.toFixed(0))}`);
}

solve(2564, 0.70, 5.5);
