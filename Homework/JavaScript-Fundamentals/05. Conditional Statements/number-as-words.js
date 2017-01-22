function solve(args) {
    const ones = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];
    const tens = ['', 'ten', 'twenty', 'thirty', 'forty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety'];
    const teens = ['', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'];
    const and = 'and';
    const hundred = 'hundred';

    var number = +args[0];
    var tempStr = '';

    if (number < 10) {
        console.log(capitalizeFirst(oneDigitToStr(number)));
    } else if (number < 100) {
        console.log(capitalizeFirst(twoDigitToStr(number)));
    } else {
        var threeDigitStr = ones[Math.floor(number / 100)] + ' ' + hundred;
        if (number % 100 == 0) {
            console.log(capitalizeFirst(threeDigitStr));
        } else {
            threeDigitStr += ' ';
            threeDigitStr += and;
            threeDigitStr += ' ';

            if (Math.floor(number / 10) % 10 == 0) {
                threeDigitStr += oneDigitToStr(number % 10);
            } else {
                threeDigitStr += twoDigitToStr(number % 100);
            }

            console.log(capitalizeFirst(threeDigitStr));
        }
    }

    function oneDigitToStr(number) {
        return ones[number];
    }

    function twoDigitToStr(number) {
        if (number % 10 == 0) {
            return tens[Math.floor(number / 10)];
        } else {
            if (number < 20) {
                return teens[number - 10];
            } else {
                return tens[Math.floor(number / 10)] + ' ' + ones[number % 10];
            }
        }
    }

    function capitalizeFirst(str) {
        return str.charAt(0).toUpperCase() + str.slice(1);
    }
}