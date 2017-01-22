function solve(args) {
    var firstNumber = +args[0];
    var secondNumber = +args[1];

    if (firstNumber > secondNumber)
    {
        var tempNumber = firstNumber;
        firstNumber = secondNumber;
        secondNumber = tempNumber;
    }

    console.log(firstNumber + " " + secondNumber);
}