function solve(args) {
    const circleX = 1;
    const circleY = 1;
    const radius = 1.5;
    const rectangleTop = 1;
    const rectangleLeft = -1;
    const rectangleWidth = 6;
    const rectangleHeight = 2;

    var pointX = +args[0];
    var pointY = +args[1];

    var distance = Math.sqrt(Math.pow(pointX - circleX, 2) + Math.pow(pointY - circleY, 2));
    var isInsideCirlce = distance <= radius;
    var isInsideRectangle = (pointX >= rectangleLeft) &&
        (pointX <= rectangleWidth + rectangleLeft) &&
        (pointY <= rectangleTop) &&
        (pointY >= rectangleTop - rectangleHeight);

    var result = (isInsideCirlce ? "inside circle " : "outside circle ") +
        (isInsideRectangle ? "inside rectangle" : "outside rectangle");

    console.log(result);
}