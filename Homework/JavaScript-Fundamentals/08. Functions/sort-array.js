function solve(args) {
    let len = args.shift();

    /*if (!args[0].trim()) {
        return '';
    }*/

    args = args[0].split(' ');
    args = args.map(function (x) {
        return +x;
    });

    console.log(Sort(args, true).join(' '));

    function Sort(src, ascending = false) {
        src = src || [];

        let pivot = 0;

        if (src.length === 1) {
            return src[0];
        }

        while (pivot < src.length - 1) {
            let max = src[pivot];
            let currentMax = findMax(pivot + 1, src);
            if (currentMax > max) {
                let maxIndex = src.indexOf(currentMax);
                // swap
                let temp = +src[pivot];
                src[pivot] = +currentMax;
                src[maxIndex] = +temp;
            }

            pivot++;
        }

        if (ascending === true) {
            src = src.reverse();
        }

        return src;
    }

    function findMax(index, src) {
        src = src || [];

        if (index === src.length - 1) {
            return src[index];
        }

        if (index < 0 || index > src.length - 1) {
            throw new Error("Invalid argument");
        }

        let maxNumber = Number.MIN_VALUE;
        for (let i = index; i < src.length; i++) {
            if (+src[i] > maxNumber) {
                maxNumber = +src[i];
            }
        }

        return maxNumber;
    }
}