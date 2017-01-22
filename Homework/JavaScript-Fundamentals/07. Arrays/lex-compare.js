function solve(args) {

    let first = args[0];
    let second = args[1];

    let result = first.localeCompare(second);
    if (result < 0) {
        console.log('<');
    } else if (result > 0) {
        console.log('>');
    } else {
        console.log('=');
    }
}