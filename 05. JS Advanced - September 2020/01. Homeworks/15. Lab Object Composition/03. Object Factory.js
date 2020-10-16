function solve(input) {
    let dataArray = JSON.parse(input);
    
    let result = dataArray.reduce((acc, curr) => {
        return ({...acc,...curr});
    }, {})

    return result;
}

solve(`[{"canFly": true},{"canMove":true, "doors": 4},{"capacity": 255},{"canFly":true, "canLand": true}]`);