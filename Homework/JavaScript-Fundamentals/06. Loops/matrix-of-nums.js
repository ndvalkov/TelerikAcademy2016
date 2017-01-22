function solve(args) {
    var N = +args[0];
    var offset = N - 2;
    var currentValue = 1;
    var i;
    var result = '';

    for (i = 1; i <= N * N; i += 1) {
        result += currentValue;
        result += ' ';

        if (i % N == 0) {
            result += '\n';
            currentValue -= offset;
        }
        else {
            currentValue++;
        }
    }

    console.log(result);
}