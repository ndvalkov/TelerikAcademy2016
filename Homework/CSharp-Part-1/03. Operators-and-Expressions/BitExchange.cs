using System;

class BitExchange
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int bitAt3 = (number >> 3) & 1;
        int bitAt4 = (number >> 4) & 1;
        int bitAt5 = (number >> 5) & 1;
        int bitAt24 = (number >> 24) & 1;
        int bitAt25 = (number >> 25) & 1;
        int bitAt26 = (number >> 26) & 1;

        // set bit at 3 to 24's value
        int swapped = (bitAt24 == 1) ?
            (1 << 3) | number :
                ~(1 << 3) & number;

        // set bit at 4 to 25's value
        swapped = (bitAt25 == 1) ?
            (1 << 4) | swapped :
                ~(1 << 4) & swapped;

        // set bit at 5 to 26's value
        swapped = (bitAt26 == 1) ?
            (1 << 5) | swapped :
                ~(1 << 5) & swapped;

        // set bit at 24 to 3's value
        swapped = (bitAt3 == 1) ?
            (1 << 24) | swapped :
                ~(1 << 24) & swapped;

        // set bit at 25 to 4's value
        swapped = (bitAt4 == 1) ?
            (1 << 25) | swapped :
                ~(1 << 25) & swapped;

        // set bit at 26 to 5's value
        swapped = (bitAt5 == 1) ?
            (1 << 26) | swapped :
                ~(1 << 26) & swapped;

        Console.WriteLine(swapped);
    }
}