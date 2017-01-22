function solve(args) {
    var firstNumber = +args[0];
    var secondNumber = +args[1];
    var thirdNumber = +args[2];
    var signOfProduct = '';

    if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0) {
        signOfProduct = '0';
    } else if ((firstNumber > 0 && secondNumber > 0) ||
        (firstNumber < 0 && secondNumber < 0)) {
        if (thirdNumber > 0) {
            signOfProduct = '+';
        } else {
            signOfProduct = '-';
        }
    } else {
        if (thirdNumber > 0) {
            signOfProduct = '-';
        } else {
            signOfProduct = '+';
        }
    }

    console.log(signOfProduct);
}