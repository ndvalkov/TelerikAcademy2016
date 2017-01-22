function solve(args) {
    args = args.map(function (x) {
        return +x;
    });

    args.shift();

    let i, j;
    let n = args.length;

    for (j = 0; j < n - 1; j++) {

        let iMin = j;
        for (i = j + 1; i < n; i++) {
            if (+args[i] < +args[iMin]) {
                iMin = i;
            }
        }

        if (iMin != j) {
            let temp = args[j];
            args[j] = args[iMin];
            args[iMin] = temp;
        }
    }

    /*args = args.filter (function (value, index, array) {
        return array.indexOf(value) == index;
    });*/

    args.forEach(function (x) {
        console.log(x);
    })
}