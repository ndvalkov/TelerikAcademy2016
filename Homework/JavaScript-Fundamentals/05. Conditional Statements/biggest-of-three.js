function solve(args) {
    var firstNumber = +args[0];
    var secondNumber = +args[1];
    var thirdNumber = +args[2];

    var biggest = firstNumber;

    if (secondNumber > biggest) {
        biggest = secondNumber;
    }

    if (thirdNumber > biggest) {
        biggest = thirdNumber;
    }

    console.log(biggest);
}