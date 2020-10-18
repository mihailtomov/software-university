function solve(area, vol, input) {
    let data = JSON.parse(input);
    let output = [];

    data.forEach(coordinatesObj => {
        let areaRes = area.call(coordinatesObj);
        let volumeRes = vol.call(coordinatesObj);
        let obj = {
            area: Math.abs(areaRes),
            volume: Math.abs(volumeRes),
        }
        output.push(obj);
    });

    return output;
}

function area() {
    return this.x * this.y;
};

function vol() {
    return this.x * this.y * this.z;
};

solve(area, vol, JSON.stringify([
    { "x": "10", "y": "-22", "z": "10" },
    { "x": "47", "y": "7", "z": "-5" },
    { "x": "55", "y": "8", "z": "0" },
    { "x": "100", "y": "100", "z": "100" },
    { "x": "55", "y": "80", "z": "250" }
])
);