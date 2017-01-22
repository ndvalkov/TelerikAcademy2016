using System;

class AppearanceCount
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

        int numberX = int.Parse(Console.ReadLine());

        Console.WriteLine(CountAppearances(numbers, numberX));
    }

    static int CountAppearances(int[] source, int target)
    {
        if (source == null)
        {
            throw new ArgumentNullException();
        }

        int count = 0;

        foreach (var item in source)
        {
            if (item == target)
            {
                ++count;
            }
        }

        return count;
    }
}