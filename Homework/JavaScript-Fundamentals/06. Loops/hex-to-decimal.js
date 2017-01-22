function solve(args) {
    var hexStr = args[0];
    var decimalNumber = 0;
    var hexDigits = "0123456789ABCDEF";
    var i;
    var j;
    var hexDigit;
    var multiplier;
    var power;
    var currentPowerOf16;

    for (i = hexStr.length - 1; i >= 0; i -= 1)
    {
        hexDigit = hexStr[i];
        multiplier = hexDigits.indexOf(hexDigit);

        power = hexStr.length - 1 - i;
        currentPowerOf16 = 1; // for first digit

        for (j = 0; j < power; j++)
        {
            currentPowerOf16 *= 16;
        }

        decimalNumber += multiplier * currentPowerOf16;
    }

    console.log(decimalNumber);
}