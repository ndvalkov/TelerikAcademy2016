using System;

class NumbersComparer
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double greaterNumber = (firstNumber >= secondNumber) ? firstNumber : secondNumber; 

        Console.WriteLine((greaterNumber % 1 == 0) ?
                          (int) greaterNumber :
                          greaterNumber);
    }
}