namespace Assertions_Homework
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class AssertionsHomework
    {
        private const string NULL_ARGUMENT_MSG = "Argument {0} cannot be null";
        private const string INVALID_ARGUMENT_EMPTY_MSG = "Invalid argument {0}, cannot be empty";
        private const string NULL_ELEMENT_MSG = "Elements from the array cannot be null";
        private const string INVALID_RANGE_MSG = "The argument {0} is not in expected range";

        public static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            // --- Precondition tests (SelectionSort/FindMinElementIndex/Swap)---

            /*int[] nullArr = null;
            SelectionSort(nullArr);*/

            /*Person[] testNullValues1 = new Person[1];
            testNullValues1[0] = null;
            SelectionSort(testNullValues1);*/

            /*Person[] testNullValues2 = new Person[4];
            testNullValues2[0] = new Person();
            testNullValues2[1] = new Person();
            testNullValues2[2] = null;
            testNullValues2[3] = new Person();
            SelectionSort(testNullValues2);*/

            /*Person[] testNullValues2 = new Person[4];
            testNullValues2[0] = new Person();
            testNullValues2[1] = new Person();
            testNullValues2[2] = null;
            testNullValues2[3] = new Person();
            FindMinElementIndex(testNullValues2, 0, 3);*/

            /* Person[] testNullValues2 = new Person[4];
             testNullValues2[0] = new Person();
             testNullValues2[1] = new Person();
             testNullValues2[2] = new Person();
             FindMinElementIndex(testNullValues2, -1, 3);*/

            /*Person[] testNullValues2 = new Person[4];
            testNullValues2[0] = new Person();
            testNullValues2[1] = new Person();
            testNullValues2[2] = new Person();
            FindMinElementIndex(testNullValues2, 0, 12);*/

            /*Person[] testNullValues2 = new Person[4];
            testNullValues2[0] = new Person();
            testNullValues2[1] = new Person();
            testNullValues2[2] = new Person();
            FindMinElementIndex(testNullValues2, 3, 2);*/

            /*int? swap1 = null;
            int? swap2 = 2;
            int? swap3 = null;
            int? swap4 = 3;
            // Swap(ref swap1, ref swap2);
            Swap(ref swap4, ref swap3);*/

            // --- Postcondition tests (SelectionSort)---

            var sorted = new int[] { -1, 0, 2, 3, 4, 15, 17, 33 };
            Debug.Assert(arr != null, "The sorted array cannot be null");
            Debug.Assert(arr.SequenceEqual(sorted), "The array is not sorted correctly");
            var empty = new int[0];
            SelectionSort(empty); // Test sorting empty array
            Debug.Assert(empty != null, "The sorted array cannot be null");
            Debug.Assert(empty.Length == 0, "The sorted array length should be 0");
            var oneElement = new int[1];
            oneElement[0] = 3;
            SelectionSort(oneElement); // Test sorting single element array
            Debug.Assert(oneElement != null, "The sorted array cannot be null");
            Debug.Assert(oneElement.Length == 1, "The sorted array length should be 1");
            Debug.Assert(oneElement.SequenceEqual(new int[] { 3 }), "The array is not sorted correctly");

            // --- Precondition tests (BinarySearch)---

            /*Person[] testNullArr = new Person[4];
            testNullArr = null;
            BinarySearch(testNullArr, new Person());*/

            /*Person[] testNullArr = new Person[4];
            var testNullElement = new Person();
            testNullElement = null;
            BinarySearch(testNullArr, testNullElement);*/

            /*Person[] testNullArr = new Person[4];
            testNullArr[0] = new Person();
            testNullArr[1] = new Person();
            testNullArr[2] = new Person();
            testNullArr = null;
            BinarySearch(testNullArr, new Person(), 0, 1);*/

            /*Person[] testNullArr = new Person[4];
            testNullArr[0] = new Person();
            testNullArr[1] = new Person();
            testNullArr[2] = new Person();
            var testNullElement = new Person();
            testNullElement = null;
            BinarySearch(testNullArr, testNullElement, 0, 1);*/

            /*Person[] testNullArr = new Person[4];
            testNullArr[0] = new Person();
            testNullArr[1] = new Person();
            testNullArr[2] = new Person();
            // BinarySearch(testNullArr, new Person(), -2, 1);
            // BinarySearch(testNullArr, new Person(), 1, 12);
            BinarySearch(testNullArr, new Person(), 1, 0);*/

            /*Person[] testNullArr = new Person[4];
            testNullArr[0] = null;
            BinarySearch(testNullArr, new Person(), 0, 1);*/

            /*Person[] testNullArr = new Person[0];
            BinarySearch(testNullArr, new Person());*/

            /*Person[] testNullArr = new Person[0];
            BinarySearch(testNullArr, new Person(), 0, 1);*/

            var copyOfArr = new List<int>(arr).ToArray();
            Array.Sort(copyOfArr);
            Debug.Assert(arr.SequenceEqual(copyOfArr), "Should not do binary search on an array which is not sorted");

            // --- Postcondition tests (BinarySearch)---

            var result = BinarySearch(arr, -1000);
            Debug.Assert(result == -1, "The result should be -1 when the value is not found");
            Console.WriteLine(result);
            result = BinarySearch(arr, 0);
            Debug.Assert(result == 1, "The position of the target element is incorrect");
            Console.WriteLine(result);
            result = BinarySearch(arr, 17);
            Debug.Assert(result == 6, "The position of the target element is incorrect");
            Console.WriteLine(result);
            result = BinarySearch(arr, 10);
            Debug.Assert(result == -1, "The result should be -1 when the value is not found");
            Console.WriteLine(result);
            result = BinarySearch(arr, 1000);
            Debug.Assert(result == -1, "The result should be -1 when the value is not found");
            Console.WriteLine(result);

            /*var newArr = new int[1];
            newArr[0] = 3;
            Console.WriteLine(BinarySearch(newArr, 3));*/
        }

        public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
        {
            Debug.Assert(arr != null, string.Format(NULL_ARGUMENT_MSG, "arr"));
            if (arr.Length == 1)
            {
                Debug.Assert(arr[0] != null, NULL_ELEMENT_MSG);
                return;
            }

            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }

        public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
        {
            Debug.Assert(arr != null, string.Format(NULL_ARGUMENT_MSG, "arr"));
            Debug.Assert(value != null, string.Format(NULL_ARGUMENT_MSG, "value"));
            Debug.Assert(arr.Length != 0, string.Format(INVALID_ARGUMENT_EMPTY_MSG, "arr"));

            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, string.Format(NULL_ARGUMENT_MSG, "arr"));
            Debug.Assert(startIndex >= 0, string.Format(INVALID_RANGE_MSG, "startIndex"));
            Debug.Assert(endIndex < arr.Length, string.Format(INVALID_RANGE_MSG, "endIndex"));
            Debug.Assert(startIndex <= endIndex, string.Format(INVALID_RANGE_MSG, "startIndex/endIndex"));

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                Debug.Assert(arr[i] != null, NULL_ELEMENT_MSG);
                Debug.Assert(arr[minElementIndex] != null, NULL_ELEMENT_MSG);

                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }

        private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
            where T : IComparable<T>
        {
            Debug.Assert(arr != null, string.Format(NULL_ARGUMENT_MSG, "arr"));
            Debug.Assert(arr.Length != 0, string.Format(INVALID_ARGUMENT_EMPTY_MSG, "arr"));
            Debug.Assert(value != null, string.Format(NULL_ARGUMENT_MSG, "value"));
            Debug.Assert(startIndex >= 0, string.Format(INVALID_RANGE_MSG, "startIndex"));
            Debug.Assert(endIndex < arr.Length, string.Format(INVALID_RANGE_MSG, "endIndex"));
            Debug.Assert(startIndex <= endIndex, string.Format(INVALID_RANGE_MSG, "startIndex/endIndex"));

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                Debug.Assert(arr[midIndex] != null, NULL_ELEMENT_MSG);

                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the left half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }

        private static void Swap<T>(ref T x, ref T y)
        {
            Debug.Assert(x != null, string.Format(NULL_ARGUMENT_MSG, "x"));
            Debug.Assert(y != null, string.Format(NULL_ARGUMENT_MSG, "y"));

            T oldX = x;
            x = y;
            y = oldX;
        }

        private class Person : IComparable<Person>
        {
            public Person()
            {
            }

            public int CompareTo(Person other)
            {
                return -1;
            }
        }
    }
}