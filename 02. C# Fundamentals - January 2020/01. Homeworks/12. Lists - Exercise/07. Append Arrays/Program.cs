using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|').Reverse().ToList();

            foreach (var item in numbers)
            {
                List<int> current = item.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                for (int i = 0; i < current.Count; i++)
                {
                    Console.Write($"{current[i]} ");
                }
            }
        }
    }
}
