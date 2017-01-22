function solve(args) {

    console.log(checkBrackets(args[0]));

    function checkBrackets(str) {
        var stack = [];
        for (let i = 0, len = str.length; i < len; i += 1) {
            if (str[i] === ')') {
                if (stack.length === 0) {
                    return 'Incorrect';
                } else {
                    stack.pop();
                }
            }

            if (str[i] === '(') {
                stack.push('(');
            }
        }

        if (stack.length !== 0) {
            return 'Incorrect';
        } else {
            return 'Correct';
        }
    }
}