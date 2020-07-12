using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int num = int.Parse(Console.ReadLine());

            Func<string[], string[]> reverseNumbers = arr =>
            {
                string[] reversedArr = new string[arr.Length];
                reversedArr = arr.Reverse().ToArray();
                return reversedArr;
            };

            numbers = reverseNumbers(numbers);

            Func<string, bool> filterNums = n => int.Parse(n) % num != 0;

            numbers = numbers.Where(filterNums).ToArray();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
