using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int i = 0; i < integers.Count; i++)
            {
                if (integers[i] < 0)
                {
                    integers.Remove(integers[i]);
                    i--;
                }
            }

            if (integers.Count == 0)
            {
                Console.WriteLine("empty");
            }

            else
            {
                integers.Reverse();
                Console.WriteLine(string.Join(" ", integers));
            }
        }
    }
}
