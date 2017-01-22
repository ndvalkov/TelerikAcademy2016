using System;
using System.Collections.Generic;
using System.Numerics;

class NumberAsArray
{
    static void Main()
    {
        string[] sizes = Console.ReadLine().Split(new char[] { ' ' });
        int sizeFirst = int.Parse(sizes[0]);
        int sizeSecond = int.Parse(sizes[1]);

        string[] firstElements = Console.ReadLine().Split(new char[] { ' ' });
        int[] first = new int[sizeFirst];

        for (int i = 0; i < first.Length; i++)
        {
            first[i] = int.Parse(firstElements[i]);
        }

        string[] secondElements = Console.ReadLine().Split(new char[] { ' ' });
        int[] second = new int[sizeSecond];

        for (int i = 0; i < second.Length; i++)
        {
            second[i] = int.Parse(secondElements[i]);
        }

        Console.WriteLine(string.Join(" ", SumNumbersAsDigitArrays(first, second)));
    }

    static int[] SumNumbersAsDigitArrays(int[] first, int[] second)
    {
        int[] result = new int[Math.Max(first.Length, second.Length)];

        int fromPreviousDigit = 0;
        int forNextDigit = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (i > second.Length - 1)
            {
                result[i] += first[i];
            } else if (i > first.Length - 1)
            {
                result[i] += second[i];
            }
            else
            {
                int sumOfDigits = first[i] + second[i];
                sumOfDigits += fromPreviousDigit;
                int resultDigit;
                
                if (sumOfDigits > 9)
                {
                    forNextDigit = 1;
                    resultDigit = sumOfDigits % 10;
                }
                else
                {
                    resultDigit = sumOfDigits;
                }

                result[i] = resultDigit;
            }

            fromPreviousDigit = forNextDigit;
            forNextDigit = 0;
        }

        if (fromPreviousDigit == 1)
        {
            List<int> resultToResize = new List<int>(result);
            resultToResize.Add(1);
            result = resultToResize.ToArray();
        }

        return result;
    }
}