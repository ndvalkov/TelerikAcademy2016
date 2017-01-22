function solve(args) {
    let maxLength = 1;
    let currentMax = 1;

    if (!+args[0]) {
        return 0;
    }

    for (let i = 1; i <= +args[0]; i++) {
        if (+args[i] === +args[i - 1]) {
            currentMax++;

            if (currentMax > maxLength) {
                maxLength = currentMax;
            }
            continue;
        }

        currentMax = 1;
    }

    console.log(maxLength);
}