using System;

class NthBit
{
    static void Main()
    {
        ulong p = ulong.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        // 1 at n-th index, n number of 0's appended
        String binaryStringOfMask = "1" + new string('0', n);
        ulong mask = Convert.ToUInt64(binaryStringOfMask, 2);
        ulong masked = mask & p;
        Console.WriteLine((masked != 0) ? 1 : 0);
    }
}