function solve(args) {
    let str = args[0];

    let result = str.replace(/<a\shref="(.*?)">(.*?)<\/a>/g, "[$2]($1)");
    console.log(result);
}