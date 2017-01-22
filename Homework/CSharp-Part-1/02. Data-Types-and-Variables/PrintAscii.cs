using System;

class PrintASCII
{
    public static void Main()
    {
        int startCode = 33;
        int endCode = 126;

        for (int currentCode = startCode; currentCode <= endCode; currentCode++)
        {
            Console.Write((char)currentCode);
        }
    }
}