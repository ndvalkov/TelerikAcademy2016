using System;

class LargerThanNeighbours
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

        Console.WriteLine(CountElementsLargerThanNeighbours(numbers));
       
    }

    static int CountElementsLargerThanNeighbours(int[] source)
    {
        int count = 0;

        for (int i = 1; i < source.Length - 1; i++)
        {
            if (source[i - 1] < source[i] && source[i] > source[i + 1])
            {
                ++count;
            }
        }

        return count;
    }
}