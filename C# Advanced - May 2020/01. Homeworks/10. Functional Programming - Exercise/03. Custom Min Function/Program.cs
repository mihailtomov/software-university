using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<int, bool> minValue = GetMinValue(nums);

            nums = nums
                .Where(minValue)
                .ToList();

            Console.WriteLine(nums[0]);           
        }

        public static Func<int, bool> GetMinValue(List<int> nums)
        {
            return num => num == nums.Min();
        }
    }
}
