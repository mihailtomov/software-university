using System;
using System.Linq;

namespace P04Froggy
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(input);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
