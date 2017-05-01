'use strict';

(function ($) {
    let getGeolocation = function () {
        return new Promise((resolve, reject) => {
            navigator.geolocation.getCurrentPosition((pos) => {
                resolve(pos);
            }, (err) => {
                reject(err);
            });
        });
    };

    let createMap = function (coords) {
        const mapURL = `http://maps.googleapis.com/maps/api/staticmap?center=${coords.lat},${coords.long}&zoom=19&size=500x500&sensor=false`;
        const $mapImg = $('<img/>');
        const $main = $('#main');

        $mapImg.attr('src', mapURL);
        $mapImg.attr('alt', 'no map available');
        $mapImg.appendTo($main);
    };

    let parseData = function (data) {
        return {
            lat: data.coords.latitude,
            long: data.coords.longitude
        }
    };

    let handleError = function (err) {
        console.log(err);
    };

    getGeolocation()
        .then(parseData)
        .then(createMap)
        .catch(handleError);
}(jQuery));