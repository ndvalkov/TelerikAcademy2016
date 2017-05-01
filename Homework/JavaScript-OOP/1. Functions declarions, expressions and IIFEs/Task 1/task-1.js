function solve() {
    return function sum(numbers) {
        if (numbers === undefined) {
            throw 'Error';
        }

        if (numbers.length === 0) {
            return null;
        }

        numbers.forEach(function (element, index) {
            if (isNaN(+element)) {
                throw 'Error';
            }

            numbers[index] = +element;
        });

        return numbers.reduce(function (a, b) {
            return a + b;
        }, 0);
    }
}