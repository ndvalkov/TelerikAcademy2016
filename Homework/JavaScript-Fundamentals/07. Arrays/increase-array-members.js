function solve(args) {

    let arr = new Array(+args[0])
        .fill(0)
        .map(function (value, index) {
            return index * 5;
        })
        .forEach(function (x) {
            console.log(x);
        })
}