function solve() {
    return function (selector) {
        if (typeof selector !== 'string' && !(selector instanceof jQuery)) {
            throw Error('');
        }


        selector = $(selector);

        var $btns = selector.find('.button');

        $btns.text('hide');

        $btns.each(function () {
            var $x = $(this);
            
            $x.on('click', function () {
                var $current = $x;
                var targetFound = false;

                do {
                    $current = $current.next();

                    if ($current === undefined || $current.length === 0 || $current.hasClass('button')) {
                        break;
                    }

                    if ($current.hasClass('content')) {
                        targetFound = true;
                        break;
                    }
                }
                while ($current.next());

                if (targetFound) {
                    $current.toggle();
                    $x.toggleText('hide', 'show');
                }
            });
        });
    };
}