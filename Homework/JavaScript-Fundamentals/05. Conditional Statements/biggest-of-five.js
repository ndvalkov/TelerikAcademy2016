function solve(args) {
    var current = Number.NEGATIVE_INFINITY;

    if (+args[0] >= current) {
        current = +args[0];

        if (+args[1] > current) {
            current = +args[1];
        }

        if (+args[2] > current) {
            current = +args[2];
        }

        if (+args[3] > current) {
            current = +args[3];
        }

        if (+args[4] > current) {
            current = +args[4];
        }
    }

    console.log(current);
}