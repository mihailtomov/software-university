function solve(data) {
    let result = [];

    data.forEach(arr => {
        let [width, height] = arr;
        let rectangle = {
            width, 
            height, 
            area: function(){
                return this.width * this.height;
            },
            compareTo: function(other){
                return other.area() - this.area() || other.width - this.width;
            }
        }
        result.push(rectangle);
    });

    return result.sort((a, b) => a.compareTo(b));
}

solve([[10,5], [3,20], [5,12]]);