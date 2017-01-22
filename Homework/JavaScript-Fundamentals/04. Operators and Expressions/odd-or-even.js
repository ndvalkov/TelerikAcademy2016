function solve(args) {
    // OddOrEven

    // var args = ['0'];

    String.prototype.format = function() {
        var formatted = this;
        for (var i = 0; i < arguments.length; i++) {
            var regexp = new RegExp('\\{'+i+'\\}', 'gi');
            formatted = formatted.replace(regexp, arguments[i]);
        }
        return formatted;
    };

    var num = +args[0];
    console.log(num % 2 == 0 ? 'even {0}'.format(num.toString()) : 'odd {0}'.format(num.toString()));
}