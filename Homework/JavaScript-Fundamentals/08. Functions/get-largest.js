function solve(args) {
    args = args[0].split(' ');

    let getMax = function(first, second) {
        first = +first;
        second = +second;

        return Math.max(first, second);
    };

    console.log(getMax(getMax(args[0], args[1]), args[2]));
}