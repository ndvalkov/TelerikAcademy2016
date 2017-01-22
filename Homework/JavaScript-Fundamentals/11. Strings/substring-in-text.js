function solve(args) {
    let target = args.shift();

    console.log(countOccurrences(target, args[0]));

    function countOccurrences(target, str) {
        if (str.trim() === '') {
            return 0;
        }

        target = target.trim().toUpperCase();
        str = str.trim().toUpperCase();

        let currentPosition = 0;
        let occurrences = 0;
        let len = str.length;

        while (currentPosition < len - target.length) {
            let newPosition = str.indexOf(target, currentPosition);
            if (newPosition !== -1) {
                currentPosition = newPosition + target.length;
                occurrences++;
            } else {
                break;
            }
        }

        return occurrences;
    }
}