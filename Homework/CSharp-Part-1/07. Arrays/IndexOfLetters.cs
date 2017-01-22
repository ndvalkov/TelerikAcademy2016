using System;

class BinarySearch
{
    static void Main()
    {
        char[] alphabet = new char['z' - 'a' + 1];

        for (int i = 'a', j = 0; i <= 'z'; i++, j++)
        {
            alphabet[j] = (char)i;
        }

        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            // Binary search for previous problem
            bool found = false;
            int first = 0;
            int last = alphabet.Length - 1;
            int mid = 0;
            char target = word[i];

            while (!found && first <= last)
            {
                mid = (first + last) / 2;

                if (target > alphabet[mid])
                {
                    first = mid + 1;
                }
                else if (target < alphabet[mid])
                {
                    last = mid - 1;
                }
                else
                {
                    found = true;
                }
            }

            Console.WriteLine(mid);
        }
    }
}