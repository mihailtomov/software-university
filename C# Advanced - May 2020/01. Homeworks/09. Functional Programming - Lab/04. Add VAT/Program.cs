using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
            .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
            .Select(decimal.Parse)
            .Select(x => x * 1.20M)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
