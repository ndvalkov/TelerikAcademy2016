function solve(args) {
    let len = args.shift();
    let target = args.pop();

    /*args.sort(function (a, b) {
     return a[1] > b[1] ? 1 : -1;
     });*/

    if (args.length == 1) {
        console.log(args[0] == target ? 0 : -1);
        return;
    }

    let lowerBound = 1;
    let upperBound = len;

    while (true) {
        if (upperBound < lowerBound) {
            console.log(-1);
            return;
        }

        let midPoint = lowerBound + Math.floor((upperBound - lowerBound) / 2);

        if (+args[midPoint] < target) {
            lowerBound = midPoint + 1;
        }

        if (+args[midPoint] > target) {
            upperBound = midPoint - 1;
        }

        if (+args[midPoint] == target) {
            console.log(midPoint);
            return;
        }
    }
}