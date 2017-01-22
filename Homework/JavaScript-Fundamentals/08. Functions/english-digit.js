function solve(args) {
    console.log(lastDigitToWord(args[0]));

    function lastDigitToWord(number) {
        var digits =
            ["zero", "one", "two", "three",
                "four", "five", "six", "seven",
                "eight", "nine"];

        return digits[number.toString().split('').pop()];
    }
}