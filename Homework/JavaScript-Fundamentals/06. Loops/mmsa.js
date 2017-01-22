function solve(args) {
    var min = Number.POSITIVE_INFINITY;
    var max = Number.NEGATIVE_INFINITY;
    var sum = 0;
    var avg = 0;

    var nextNumber;
    var currentIndex = 0;

    while (true) {
        nextNumber = +args[currentIndex++];

        if (nextNumber > max)
        {
            max = nextNumber;
        }

        if (nextNumber < min)
        {
            min = nextNumber;
        }

        sum += nextNumber;

        if (currentIndex == args.length) {
            break;
        }
    }

    avg = sum / args.length;

    console.log('min=' + min.toFixed(2));
    console.log('max=' + max.toFixed(2));
    console.log('sum=' + sum.toFixed(2));
    console.log('avg=' + avg.toFixed(2));
}