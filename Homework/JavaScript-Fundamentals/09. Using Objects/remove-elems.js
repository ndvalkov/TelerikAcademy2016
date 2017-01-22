function solve(args) {
    var target = args.shift();

    Array.prototype.removeAll = function (element) {
        while(this.indexOf(element) !== -1) {
            var pos = this.indexOf(element);
            this.splice(pos, 1);
        }
    };

    args.removeAll(target);

    console.log(args.join('\n'));
}