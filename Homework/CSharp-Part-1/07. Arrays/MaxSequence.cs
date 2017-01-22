using System;

class MaximalSequence
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int[] numbers = new int[N];

        int maxSequence = 1;
        int currentSequence = 1;

        int nextElement = int.Parse(Console.ReadLine());
        numbers[0] = nextElement;
        for (int i = 1; i < N; i++)
        {
            nextElement = int.Parse(Console.ReadLine());
            numbers[i] = nextElement;

            if (numbers[i] == numbers[i - 1])
            {
                currentSequence++;
                if (currentSequence > maxSequence)
                {
                    maxSequence = currentSequence;
                }
            }
            else
            {
                currentSequence = 1;
            }
        }

        Console.WriteLine(maxSequence);
    }
}