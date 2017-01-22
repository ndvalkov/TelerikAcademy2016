using System;

class PointCircleRectangle
{
    static void Main()
    {
        double pointX = double.Parse(Console.ReadLine());
        double pointY = double.Parse(Console.ReadLine());
        double circleX = 1;
        double circleY = 1;
        double radius = 1.5;
        double rectangleTop = 1;
        double rectangleLeft = -1;
        double rectangleWidth = 6;
        double rectangleHeight = 2;

        double distance = Math.Sqrt(Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2));
        bool isInsideCirlce = distance <= radius;
        bool isInsideRectangle = (pointX >= rectangleLeft) &&
            (pointX <= rectangleWidth + rectangleLeft) &&
            (pointY <= rectangleTop) &&
            (pointY >= rectangleTop - rectangleHeight);

        Console.Write(isInsideCirlce ? "inside circle " : "outside circle ");
        Console.Write(isInsideRectangle ? "inside rectangle" : "outside rectangle");
    }
}