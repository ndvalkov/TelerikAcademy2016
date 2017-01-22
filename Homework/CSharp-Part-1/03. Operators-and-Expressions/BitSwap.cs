using System;

class BitSwap
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        uint swapped = n;

        for (int currentNumber = 1; currentNumber <= k; currentNumber++) 
        {
            uint bitAtFirstPosition = (n >> p) & (uint)1;
            uint bitAtSecondPosition = (n >> q) & (uint)1;

            // set bit at second position to the value of first
            swapped = (bitAtFirstPosition == 1) ?
                ((uint)1 << q) | swapped :
                    ~((uint)1 << q) & swapped;

            // set bit at first position to the value of second
            swapped = (bitAtSecondPosition == 1) ?
                ((uint)1 << p) | swapped :
                    ~((uint)1 << p) & swapped;

            p++;
            q++;
        }

        Console.WriteLine(swapped);
    }
}