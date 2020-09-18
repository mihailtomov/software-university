using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], List<int>> sortNumbers = evenNums =>
            {
                int[] oddNums = new int[evenNums.Length];
                Array.Copy(evenNums, oddNums, evenNums.Length);

                evenNums = evenNums
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

                oddNums = oddNums
                .Where(x => x % 2 != 0)
                .OrderBy(x => x)
                .ToArray();

                List<int> sortedList = new List<int>();
                AddSortedNumbers(evenNums, sortedList);
                AddSortedNumbers(oddNums, sortedList);

                return sortedList;
            };

            List<int> result = sortNumbers(numbers);
            Console.WriteLine(string.Join(" ", result));
        }

        private static void AddSortedNumbers(int[] arr, List<int> sortedList)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                sortedList.Add(arr[i]);
            }
        }
    }
}
