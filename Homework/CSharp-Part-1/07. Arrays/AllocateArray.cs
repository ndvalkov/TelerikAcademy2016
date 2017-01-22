using System;

class AllocateArray
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] numbers = new int[N];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i * 5;
            Console.WriteLine(numbers[i]);
        }
    }
}