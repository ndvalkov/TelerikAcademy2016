function solve(args) {
    let len = +args.shift();
    args = args[0].split(" ");

    console.log(firstLarger(args));

    function firstLarger(arr) {
        for (let i = 0; i < arr.length; i++) {
            if (isLargerThanNeighbour(i, arr)) {
                return i;
            }
        }

        return -1;
    }

    function isLargerThanNeighbour(index, src) {
        src = src || [];

        if (index === 0 || index === src.length - 1) {
            return false;
        }

        return +src[index - 1] < +src[index] && +src[index] > +src[index + 1];
    }
}