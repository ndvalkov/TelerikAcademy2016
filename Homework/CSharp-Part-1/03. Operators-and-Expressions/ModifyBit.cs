using System;

class ModifyBit
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());
        ulong modified = (v == 1) ?
            ((ulong)1 << p) | n :
            ~((ulong)1 << p) & n;

        Console.WriteLine(modified);
    }
}