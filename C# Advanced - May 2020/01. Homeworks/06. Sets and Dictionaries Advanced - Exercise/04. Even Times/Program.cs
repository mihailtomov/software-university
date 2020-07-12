using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> nums = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(num))
                {
                    nums[num] = 1;
                }
                else
                {
                    nums[num]++;
                }
            }

            foreach (var num in nums)
            {
                int evenNum = num.Key;
                int count = num.Value;

                if (count % 2 == 0)
                {
                    Console.WriteLine(evenNum);
                    break;
                }
            }
        }
    }
}
