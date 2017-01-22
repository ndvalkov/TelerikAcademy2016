function solve(args) {
    let len = args.shift();

    let obj = {};
    let maxTimes = 1;
    let maxValue;

    for (let i = 0; i < args.length; i++) {

        if (obj.hasOwnProperty(args[i])){
            obj[args[i]]++;

            if (obj[args[i]] > maxTimes) {
                maxTimes = obj[args[i]];
                maxValue = args[i];
            }
        } else {
            obj[args[i]] = 1;
        }
    }

    console.log(`${maxValue} (${maxTimes} times)`);
}