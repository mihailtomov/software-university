using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] realNums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var dictionary = new SortedDictionary<double, int>();

            for (int i = 0; i < realNums.Length; i++)
            {
                if (!dictionary.ContainsKey(realNums[i]))
                {
                    dictionary[realNums[i]] = 1;
                }

                else
                {
                    dictionary[realNums[i]]++;
                }
            }

            foreach (var num in dictionary)
            {
                Console.WriteLine($"{num.Key} -> {num.Value}");
            }
        }
    }
}
