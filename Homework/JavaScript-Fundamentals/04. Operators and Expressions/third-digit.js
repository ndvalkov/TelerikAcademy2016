function solve(args) {
    // ThirdDigit

    // const args = ['9999799'];

    var number = +args[0];

    var thirdDigit = (Math.floor(number / 100)) % 10;
    var targetDigit = 7;

    console.log((thirdDigit == targetDigit) ?
        'true' :
        'false ' + thirdDigit);
}