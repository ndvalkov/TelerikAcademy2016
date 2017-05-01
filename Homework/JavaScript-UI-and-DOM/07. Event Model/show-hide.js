function solve() {
    return function (selector) {
        const HIDE = 'hide';
        const SHOW = 'show';
        const BUTTON_CLASS = 'button';
        const CONTENT_CLASS = 'content';

        var selected;

        if (typeof selector === 'string') {
            selected = document.getElementById(selector);

            if (selected === null) {
                throw Error('Invalid selector');
            }
        } else if (selector instanceof HTMLElement) {
            if (!selector.ownerDocument.body.contains(selector)) {
                throw Error('The element is not attached to document');
            }

            selected = selector;

        } else {
            throw Error('Invalid argument');
        }

        var withClassButton = selected.getElementsByClassName(BUTTON_CLASS);
        var withClassContent = selected.getElementsByClassName(CONTENT_CLASS);

        withClassButton = [].slice.call(withClassButton);
        withClassContent = [].slice.call(withClassContent);

        withClassButton.forEach(function (x) {
            x.textContent = HIDE;

            x.addEventListener('click', function () {
                var targetContent = x.nextElementSibling;

                while(targetContent !== null) {
                    if (targetContent.className === BUTTON_CLASS) {
                        targetContent = null;
                        break;
                    }

                    if (targetContent.className === CONTENT_CLASS) {
                        break;
                    }

                    targetContent = targetContent.nextElementSibling;
                }

                if (targetContent === null || targetContent === undefined) {
                    return;
                }

                if (targetContent.style.display === 'none') {
                    targetContent.style.display = '';
                    x.textContent = HIDE;
                } else {
                    targetContent.style.display = 'none';
                    x.textContent = SHOW;
                }
            }, false);
        });
    };
}