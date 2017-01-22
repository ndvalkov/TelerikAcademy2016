using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int arraySize = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        string[] elements = input.Split(new char[] { ' ' });

        int[] numbers = new int[arraySize];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(elements[i]);
        }

        Console.WriteLine(IndexOfLargerThanNeighbours(numbers));
       
    }

    static int IndexOfLargerThanNeighbours(int[] source)
    {
        int index = -1;

        for (int i = 1; i < source.Length - 1; i++)
        {
            if (source[i - 1] < source[i] && source[i] > source[i + 1])
            {
                index = i;
                break;
            }
        }

        return index;
    }
}
