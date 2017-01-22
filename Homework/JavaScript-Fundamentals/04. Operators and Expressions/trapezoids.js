function solve(args) {
    // Trapezoid

    var a = +args[0];
    var b = +args[1];
    var h = +args[2];

    var area = h * ((a + b) / 2);

    console.log(area.toFixed(7));
}