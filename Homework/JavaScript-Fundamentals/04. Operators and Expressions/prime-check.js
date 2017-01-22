function solve(args) {
    // PrimeCheck

    var num = +args[0];
    var maxValue = 100;
    var boundary = Math.sqrt(maxValue); // 10

// check for dividers in the range [2, 10]
    var isPrime = (num > 1) &&
        !((num % 2 == 0) && (num != 2)) &&
        !((num % 3 == 0) && (num != 3)) &&
        !((num % 4 == 0) && (num != 4)) &&
        !((num % 5 == 0) && (num != 5)) &&
        !((num % 6 == 0) && (num != 6)) &&
        !((num % 7 == 0) && (num != 7)) &&
        !((num % 8 == 0) && (num != 8)) &&
        !((num % 9 == 0) && (num != 9)) &&
        !((num % boundary == 0) && (num != boundary));

    console.log(isPrime);
}