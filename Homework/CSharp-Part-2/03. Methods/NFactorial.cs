using System;

class NFactorial
{
    static void Main()
    {
        // http://www.geeksforgeeks.org/factorial-large-number/

        int n = int.Parse(Console.ReadLine());

        // Maximum number of digits in output
        int maxDigits = 500;
        int[] res = new int[maxDigits];

        // Initialize result
        res[0] = 1;
        int res_size = 1;

        // Apply simple factorial formula n! = 1 * 2 * 3 * 4...*n
        for (int x = 2; x <= n; x++)
        {
            res_size = Multiply(x, res, res_size);
        }

        string result = "";

        for (int i = res_size - 1; i >= 0; i--)
        {
            result += res[i];
        }

        Console.WriteLine(result);
    }

    // This function multiplies x with the number represented by res[].
    // res_size is size of res[] or number of digits in the number represented
    // by res[]. This function uses simple school mathematics for multiplication.
    // This function may value of res_size and returns the new value of res_size
    static int Multiply(int x, int[] res, int res_size)
    {
        int carry = 0;  // Initialize carry

        // One by one multiply n with individual digits of res[]
        for (int i = 0; i < res_size; i++)
        {
            int prod = res[i] * x + carry;
            res[i] = prod % 10;   // Store last digit of 'prod' in res[]
            carry = prod / 10;    // Put rest in carry
        }

        // Put carry in res and increase result size
        while (carry > 0)
        {
            res[res_size] = carry % 10;
            carry = carry / 10;
            res_size++;
        }

        return res_size;
    }
}