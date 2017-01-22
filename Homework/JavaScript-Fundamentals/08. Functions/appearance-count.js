function solve(args) {
    let len = +(args.shift());
    let target = +(args.pop());
    args = args[0].split(' ');

    console.log(countAppearances(args, target))

    function countAppearances(source, target) {
        source = source | [];

        let len = args.length;
        let count = 0;
        for (let i = 0; i < len; i++) {
            if (args[i] == target) {
                count += 1;
            }
        }
        return count;
    }
}