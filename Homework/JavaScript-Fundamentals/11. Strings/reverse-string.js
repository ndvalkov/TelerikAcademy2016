function solve(args) {
    console.log(reverseString(args[0]));

    function reverseString(str) {
        let arr = str.split("");
        let reversed = arr.reverse();
        return reversed.join("");
    }
}