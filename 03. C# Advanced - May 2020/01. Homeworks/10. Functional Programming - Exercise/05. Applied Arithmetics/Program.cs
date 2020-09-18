using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command;

            Action<List<int>> print = list => Console.WriteLine(string.Join(" ", list));

            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add": 
                        numbers = numbers.Select(x => x + 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(x => x * 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(x => x - 1).ToList();
                        break;
                    default:
                        print(numbers);
                        break;
                }
            }
        }
    }
}
