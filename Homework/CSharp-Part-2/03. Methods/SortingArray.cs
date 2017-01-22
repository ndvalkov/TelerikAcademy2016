using System;
using System.Linq;

class SortingArray
{
    static void Main()
    {
        int sizeOfArray = int.Parse(Console.ReadLine());
        string[] elements = Console.ReadLine().Split(new char[] { ' ' });

        double[] numbers = new double[sizeOfArray];

        for (int i = 0; i < sizeOfArray; i++)
        {
            numbers[i] = double.Parse(elements[i]);
        }

        Sort(numbers);
        Console.WriteLine(string.Join(" ", numbers));
    }

    static double FindBiggest(double[] source, int startIndex)
    {
        double biggest = double.MinValue;
        for (int i = startIndex; i < source.Length; i++)
        {
            if (source[i] > biggest)
            {
                biggest = source[i];
            }
        }

        return biggest;
    }

    static void Sort(double[] source, bool ascending = true)
    {
        int currentIndex;
        int lastIndex;
        int step;

        currentIndex = 0;
        lastIndex = source.Length - 1;
        step = 1;

        //if (ascending)
        //{
        //    currentIndex = 0;
        //    lastIndex = source.Length - 1;
        //    step = 1;
        //}
        //else
        //{
        //    currentIndex = source.Length - 1;
        //    lastIndex = 0;
        //    step = -1;
        //}

        while (currentIndex != lastIndex)
        {
            double biggest = FindBiggest(source, currentIndex);
            int indexOfBiggest = Array.IndexOf(source, biggest);
            // swap
            double temp = source[currentIndex];
            source[currentIndex] = biggest;
            source[indexOfBiggest] = temp;

            currentIndex += step;
        }

        if (!ascending)
        {
            source = source.OrderByDescending(e => e).ToArray();
        }

        Array.Reverse(source);
    }
}