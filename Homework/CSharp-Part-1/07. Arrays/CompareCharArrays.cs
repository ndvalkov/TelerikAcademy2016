using System;

class CompareArrays
{
    static void Main()
    {
        string first = Console.ReadLine();
        string second = Console.ReadLine();

        int length = (first.Length < second.Length) ? first.Length : second.Length;
        string result = "equal";
        for (int i = 0; i < length; i++)
        {
            if (first[i] < second[i])
            {
                result = "firstSmaller";
                break;
            }

            if (first[i] > second[i])
            {
                result = "secondSmaller";
                break;
            }

            if (i == length - 1)
            {
                if (first.Length < second.Length)
                {
                    result = "firstSmaller";
                }

                if (first.Length > second.Length)
                {
                    result = "secondSmaller";
                }
            }
        }

        if (result == "equal")
        {
            Console.WriteLine('=');
        }
        else if (result == "firstSmaller")
        {
            Console.WriteLine('<');
        }
        else
        {
            Console.WriteLine('>');
        }
    }
}
