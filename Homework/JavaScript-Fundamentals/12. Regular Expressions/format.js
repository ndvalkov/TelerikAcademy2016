function solve(args) {
    let optionsAsJSON = args.shift();
    let template = args.shift();

    String.prototype.format = function (optionsAsJSON) {
        let parsedOptions = JSON.parse(optionsAsJSON);
        let result = this;

        for (let p in parsedOptions) {
            if (parsedOptions.hasOwnProperty(p)) {
                let pattern = '#{' + p + '}';
                let rx = new RegExp(pattern, 'g');
                result = result.replace(rx, parsedOptions[p]);
            }
        }

        return result;
    };

    template = template.format(optionsAsJSON);
    console.log(template);
}