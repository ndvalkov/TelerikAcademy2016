function solve(args) {
    let up = '<upcase>';
    let low = '<lowcase>';
    let org = '<orgcase>';

    let str = args[0];
    let result = '';

    let caseStack = [];

    for (let i = 0, len = str.length; i < len; i += 1) {
        if (str[i] === '<') {
            if (str[i + 1] === 'u') {
                // upper case
                i += up.length;
                caseStack.push(up);
            } else if (str[i + 1] === 'l') {
                // lower case
                i += low.length;
                caseStack.push(low);
            } else if (str[i + 1] === 'o') {
                // orgcase
                i += org.length;
                caseStack.push(org);
            } else {
                // closing tag
                if (str[i + 2] === 'u') {
                    i += up.length + 1;
                    caseStack.pop();
                } else if (str[i + 2] === 'l') {
                    i += low.length + 1;
                    caseStack.pop();
                } else {
                    i += org.length + 1;
                    caseStack.pop();
                }
            }
        }

        if (caseStack.length === 0 && i < str.length) {
            result += str[i];
        } else {
            switch (caseStack[caseStack.length - 1]) {
                case up: result += str[i].toUpperCase(); break;
                case low: result += str[i].toLowerCase(); break;
                case org: result += str[i]; break;
            }
        }
    }

    console.log(result);
}