using System;

class ThirdBit
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        // 1 at bit index 3
        uint mask = Convert.ToUInt32("00001000", 2);
        uint masked = mask & number;
        Console.WriteLine((masked != 0) ? 1 : 0);
    }
}