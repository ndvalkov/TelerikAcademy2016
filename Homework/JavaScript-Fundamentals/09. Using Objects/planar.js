function solve(args) {
    args = args.map(function (x) {
        return +x;
    });

    var lines = [];
    for (var i = 0, len = args.length; i < len - 3; i += 4) {
        var point = {};
        point.x = args[i];
        point.y = args[i + 1];
        var line = [];
        line.push(point);

        point = {};
        point.x = args[i + 2];
        point.y = args[i + 3];
        line.push(point);

        lines.push(line);
    }

    a = calculateDistance(lines[0][0], lines[0][1]).toFixed(2);
    b = calculateDistance(lines[1][0], lines[1][1]).toFixed(2);
    c = calculateDistance(lines[2][0], lines[2][1]).toFixed(2);
    console.log(a);
    console.log(b);
    console.log(c);
    console.log((canFormTriangle(a, b, c) ?
        'Triangle can be built' :
        'Triangle can not be built'));

    function calculateDistance(startPoint, endPoint) {
        return Math.sqrt((startPoint.x - endPoint.x) *
            (startPoint.x - endPoint.x) + (startPoint.y - endPoint.y) *
            (startPoint.y - endPoint.y));
    }

    function canFormTriangle(a, b, c) {
        return (a + b) > c && (a + c) > b && (b + c) > a;
    }

    /*function canBuildTriangle(lineOne, lineTwo, lineThree) {
        return haveSameEdges(lineOne, lineTwo) &&
            haveSameEdges(lineOne, lineThree) &&
            haveSameEdges(lineTwo, lineThree);
    }

    function haveSameEdges(lineOne, lineTwo) {
        return areEqual(lineOne[0], lineTwo[0]) ||
        areEqual(lineOne[0], lineTwo[1]) ||
        areEqual(lineOne[1], lineTwo[0]) ||
        areEqual(lineOne[1], lineTwo[1]);
    }*/

    /*function areEqual(pointOne, pointTwo) {
        return pointOne.x === pointTwo.x && pointOne.y === pointTwo.y;
    }*/
}