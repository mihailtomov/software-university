function solve(input) {
    let output = [];

    input.forEach(([width, height]) => {
        output.push(
            {
                width,
                height,
                area: function () {
                    return this.width * this.height;
                },
                compareTo: function (other) {
                    return other.area() - this.area() || other.width - this.width;
                }
            }
        )
    })

    return output.sort((a, b) => a.compareTo(b));
}

console.log(solve([[10,5], [3,20], [5,12]]));