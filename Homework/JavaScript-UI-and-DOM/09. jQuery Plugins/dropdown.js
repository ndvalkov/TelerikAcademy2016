function solve() {
    return function (selector) {
        var $node = $(selector);

        var $container = $('<div />').addClass('dropdown-list');

        var $current = $('<div />')
            .addClass('current')
            .attr('data-value', "")
            .text('Select a value')
            .on('click', function () {
                var $this = $(this);

                var $next = $this.next();
                if ($next !== null) {
                    $next.toggle();
                }
            })
            .appendTo($container);

        var $options = $('<div />')
            .addClass('options-container')
            .css('position', 'absolute')
            .css('display', 'none');

        for(var i = 0; i < 5; i += 1) {
            var $item = $('<div />')
                .addClass('dropdown-item')
                .attr('data-value', "value-" + (i + 1))
                .attr('data-index', "value-" + i)
                .text('Option ' + (i + 1))
                .appendTo($options);
        }

        $options.appendTo($container);
        $node
            .clone()
            .hide()
            .prependTo($container);

        $node.replaceWith($container);
    };
}