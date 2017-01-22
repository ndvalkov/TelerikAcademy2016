function solve(args) {
    // DivideBy7And5
    // var args = ['24'];

    var result = ((+args[0] % 5 == 0) && (+args[0] % 7 == 0) ?
        'true ' + (+args[0]) :
        'false ' + (+args[0]));

    console.log(result);
}