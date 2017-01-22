using System;

class SumOfNNumbers
{
    static void Main()
    {
        int N;
        bool isNValid = int.TryParse(Console.ReadLine(), out N);

        double sum = 0;
        for (int i = 1; i <= N; i++)
        {
            checked
            {
                sum += double.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine(isNValid ?
                          Convert.ToString(sum) :
                          "Not a valid count.");
    }
}