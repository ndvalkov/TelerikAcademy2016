function solve(args) {
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    var firstRoot;
    var secondRoot;

    var sqrtPart = (b * b) - (4 * a * c);

    if (sqrtPart < 0) {
        console.log('no real roots');
    } else {
        firstRoot = (-b + Math.sqrt(sqrtPart)) / (2 * a);
        secondRoot = (-b - Math.sqrt(sqrtPart)) / (2 * a);

        if (sqrtPart == 0) {
            console.log('x1=x2=' + firstRoot.toFixed(2));
        } else {
            console.log('x1=' +
                Math.min(firstRoot, secondRoot).toFixed(2) +
                '; ' +
                'x2=' +
                Math.max(firstRoot, secondRoot).toFixed(2));
        }
    }
}