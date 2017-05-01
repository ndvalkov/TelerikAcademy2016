'use strict';

let taskController = (function ($) {

    let wait = function (time) {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                resolve();
            }, time);
        });
    };

    let redirect = function (url) {
        window.location.href = url;
    };

    function showPopup(msg) {
        const $popup = $(`<div class="popup"/>`);
        const $main = $('#main');
        const $close = $('<span class="close">&times;</span>');

        $popup.html(`
            <div class="popup-content">
                <p>${msg}</p>
            </div>
        `);

        $close.on('click', () => {
            $popup.css('display', 'none');
        });

        $popup.children().prepend($close);
        $popup.css('display', 'block');
        $popup.appendTo($main);

        wait(2000)
            .then(() => {
                redirect('http://www.hbo.com/game-of-thrones/about/video/season-7-sigils-tease.html?autoplay=true');
            });
    }

    return {
        showPopup
    }
}(jQuery));