using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Func<string, int> parseToInt = x => int.Parse(x);

            int[] output = input
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parseToInt)
                .ToArray();

            Console.WriteLine(output.Length);
            Console.WriteLine(output.Sum());
        }
    }
}
