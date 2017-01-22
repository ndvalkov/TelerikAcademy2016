function solve(args) {

    args = args.map(function (x) {
       return +x;
    });

    args.shift;

    let maxSequence = 1;
    let currentSequence = 1;

    for (let i = 1; i < args.length; i += 1) {

        if (args[i] > args[i - 1]) {
            currentSequence += 1;

            if (currentSequence > maxSequence) {
                maxSequence = currentSequence;
            }

            continue;
        }

        currentSequence = 1;
    }

    console.log(maxSequence);
}