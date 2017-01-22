function solve(args) {
    let len = args.shift();
    args = args[0].split(" ");

    args.map(function (x) {
        return +x;
    });

    console.log(CountElementsLargerThanNeighbours(args));

    function CountElementsLargerThanNeighbours(src) {
        src = src || [];

        let count = 0;

        for (let i = 0, len = args.length; i < len; i += 1) {
            if(isLargerThanNeighbour(i, args)) {
                count++;
            }
        }

        return count;
    }

    function isLargerThanNeighbour(index, src) {
        src = src || [];

        if (index === 0 || index === src.length - 1) {
            return false;
        }

        return +src[index - 1] < +src[index] && +src[index] > +src[index + 1];
    }
}