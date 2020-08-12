using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(numArray);

            string command;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("add"))
                {
                    for (int i = 1; i < splitArgs.Length; i++)
                    {
                        numbers.Push(int.Parse(splitArgs[i]));
                    }
                }
                else
                {
                    int numsToRemove = int.Parse(splitArgs[1]);

                    if (numbers.Count >= numsToRemove)
                    {
                        for (int i = 0; i < numsToRemove; i++)
                        {
                            numbers.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {numbers.Sum()}");
        }
    }
}
