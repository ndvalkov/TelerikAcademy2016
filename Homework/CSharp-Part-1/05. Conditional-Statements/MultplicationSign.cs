using System;

class MultiplicationSign
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());
        char signOfProduct;

        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            signOfProduct = '0';
        }
        else if ((firstNumber > 0 && secondNumber > 0) ||
                (firstNumber < 0 && secondNumber < 0))
        {
            if (thirdNumber > 0)
            {
                signOfProduct = '+';
            } else
            {
                signOfProduct = '-';
            }
        }
        else
        {
            if (thirdNumber > 0)
            {
                signOfProduct = '-';
            }
            else
            {
                signOfProduct = '+';
            }
        }

        Console.WriteLine(signOfProduct);
    }
}
