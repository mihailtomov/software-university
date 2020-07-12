using System;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] doubleNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> nums = new Dictionary<string, int>();

            for (int i = 0; i < doubleNums.Length; i++)
            {
                string currNum = doubleNums[i];

                if (!nums.ContainsKey(currNum))
                {
                    nums[currNum] = 1;
                }
                else
                {
                    nums[currNum]++;
                }
            }

            foreach (var kvp in nums)
            {
                string currNum = kvp.Key;
                int count = kvp.Value;

                Console.WriteLine($"{currNum} - {count} times");
            }
        }
    }
}
