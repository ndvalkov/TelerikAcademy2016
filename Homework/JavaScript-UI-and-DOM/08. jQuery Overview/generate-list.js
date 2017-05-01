function solve() {
    var UL_CLASS = 'items-list';
    var LI_CLASS = 'list-item';

    var contentFormat = 'List item #';

    return function (selector, count) {
        if (typeof selector !== 'string') {
            throw Error('');
        }

        if (Array.isArray(count) || count.length === 0) {
            throw Error('');
        }

        if (typeof count == 'number' && count < 1) {
            throw Error('');
        }

        if (arguments.length < 2 || Number.isNaN(+count)) {
            throw Error('');
        }

        if ($(selector).length === 0) {
            return;
        }

        var $target = $(selector);

        var $ul = $('<ul/>');
        $ul.addClass(UL_CLASS);

        for (var i = 0; i < +count; i += 1) {
            var $li = $('<li/>');
            $li.addClass(LI_CLASS);
            $li.text(contentFormat + i);

            $li.appendTo($ul);
        }

        $ul.appendTo($target);
    };
}