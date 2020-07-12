using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input);
            Dictionary<string, List<int>> halls = new Dictionary<string, List<int>>();
            Queue<string> hallLetters = new Queue<string>();

            while (stack.Any())
            {
                string currItem = stack.Peek();

                var isNumeric = int.TryParse(currItem, out _);

                if (isNumeric == false)
                {
                    halls[currItem] = new List<int>();
                    hallLetters.Enqueue(currItem);
                    stack.Pop();
                    continue;
                }

                if (!halls.Any())
                {
                    stack.Pop();
                    continue;
                }

                foreach (var kvp in halls)
                {
                    string hall = kvp.Key;
                    List<int> capacity = kvp.Value;

                    if (capacity.Sum() + int.Parse(currItem) <= hallCapacity)
                    {
                        capacity.Add(int.Parse(currItem));
                        stack.Pop();
                        break;
                    }
                    if (capacity.Sum() + int.Parse(currItem) > hallCapacity && hallLetters.Any())
                    {
                        Console.WriteLine($"{hallLetters.Dequeue()} -> {string.Join(", ", capacity)}");
                        halls.Remove(hall);
                        break;
                    }
                }
            }
        }
    }
}
