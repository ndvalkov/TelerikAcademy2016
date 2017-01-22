function solve(args) {
    // PointInACircle
    const radius = 2;

    var x = +args[0];
    var y = +args[1];

    var distance = Math.sqrt(x * x + y * y);

    console.log((distance <= radius) ?
        'yes ' + distance.toFixed(2) :
        'no ' + distance.toFixed(2));
}