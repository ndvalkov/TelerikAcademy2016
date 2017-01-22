function solve(args) {
    var firstNumber = +args[0];
    var secondNumber = +args[1];
    var thirdNumber = +args[2];
    var result = '';

    if (firstNumber >= secondNumber && firstNumber >= thirdNumber) { // first biggest
        result += firstNumber;
        result += " ";

        if (secondNumber >= thirdNumber) {
            result += secondNumber;
            result += " ";
            result += thirdNumber;
        } else {
            result += thirdNumber;
            result += " ";
            result += secondNumber;
        }
    } else if (secondNumber >= firstNumber && secondNumber >= thirdNumber) { // second biggest
        result += secondNumber;
        result += " ";

        if (firstNumber >= thirdNumber) {
            result += firstNumber;
            result += " ";
            result += thirdNumber;
        } else {
            result += thirdNumber;
            result += " ";
            result += firstNumber;
        }
    } else {// third biggest
        result += thirdNumber;
        result += " ";

        if (firstNumber >= secondNumber) {
            result += firstNumber;
            result += " ";
            result += secondNumber;
        } else {
            result += secondNumber;
            result += " ";
            result += firstNumber;
        }
    }

    console.log(result);
}