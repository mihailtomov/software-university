using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(number => int.Parse(number)).ToList();

            nums = nums.OrderByDescending(num => num).ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i <= 2)
                {
                    Console.Write($"{nums[i]} ");
                }
            }
        }
    }
}
