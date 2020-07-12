using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            int lowerBound = range[0];
            int upperBound = range[1];

            List<int> nums = new List<int>();

            for (int num = lowerBound; num <= upperBound; num++)
            {
                nums.Add(num);
            }

            Predicate<int> tester = ListOddOrEven(command);

            foreach (var num in nums)
            {
                if (tester(num))
                {
                    Console.Write($"{num} ");
                }
            }
        }

        static Predicate<int> ListOddOrEven(string command)
        {
            switch (command)
            {
                case "odd": return nums => nums % 2 != 0;
                case "even": return nums => nums % 2 == 0;
                default: return null;
            }
        }
    }
}
