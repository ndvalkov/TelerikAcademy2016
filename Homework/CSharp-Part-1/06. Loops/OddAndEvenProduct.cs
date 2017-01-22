using System;

class OddAndEvenProduct
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string sequence = Console.ReadLine();

        string[] numbers = sequence.Split(' ');

        if (numbers.Length != N)
        {
            Console.WriteLine("Invalid sequence.");
            return;
        }

        ulong oddProduct = 1;
        ulong evenProduct = 1;

        for (int i = 0; i < N; i++)
        {
            // even index is odd position
            if (i % 2 == 0)
            {
                oddProduct *= ulong.Parse(numbers[i]);
            }
            else
            {
                evenProduct *= ulong.Parse(numbers[i]);
            }
        }

        if (oddProduct == evenProduct)
        {
            Console.WriteLine("yes " + oddProduct);
        }
        else
        {
            Console.WriteLine("no " + oddProduct + " " + evenProduct);
        }
    }
}