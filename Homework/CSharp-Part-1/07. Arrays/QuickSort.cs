using System;

class QuickSort
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        double[] numbers = new double[N];
        for (int i = 0; i < N; i++)
        {
            double nextElement = double.Parse(Console.ReadLine());
            numbers[i] = nextElement;
        }

        // quicksort(A, 1, length(A))
        Quicksort(numbers, 0, numbers.Length - 1);

        // print
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }

    // https://en.wikipedia.org/wiki/Quicksort
    //algorithm quicksort(A, lo, hi) is
    //    if lo < hi then
    //        p := partition(A, lo, hi)
    //        quicksort(A, lo, p – 1)
    //        quicksort(A, p + 1, hi)
    private static void Quicksort(double[] numbers, int low, int high)
    {
        if (low < high)
        {
            int p = Partition(numbers, low, high);
            Quicksort(numbers, low, p - 1);
            Quicksort(numbers, p + 1, high);
        }
    }

    // https://en.wikipedia.org/wiki/Quicksort
    //algorithm partition(A, lo, hi) is
    //    pivot := A[hi]
    //    i:= lo        // place for swapping
    //    for j := lo to hi – 1 do
    //                if A[j] ≤ pivot then
    //            swap A[i] with A[j]
    //            i:= i + 1
    //    swap A[i] with A[hi]
    //    return i
    private static int Partition(double[] numbers, int low, int high)
    {
        double pivot = numbers[high];
        int i = low;    // place for swapping

        for (int j = low; j <= high - 1; j++)
        {
            if (numbers[j] <= pivot)
            {
                // swap A[i] with A[j]
                double temp_j = numbers[j];
                numbers[j] = numbers[i];
                numbers[i] = temp_j;

                i++;
            }
        }

        // swap A[i] with A[hi]
        double temp_high = numbers[high];
        numbers[high] = numbers[i];
        numbers[i] = temp_high;

        return i;
    }
}