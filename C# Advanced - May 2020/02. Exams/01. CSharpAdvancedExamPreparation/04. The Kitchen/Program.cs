using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._The_Kitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            var knivesData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var forksData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> knives = new Stack<int>(knivesData);
            Queue<int> forks = new Queue<int>(forksData);
            List<int> createdSets = new List<int>();

            while (knives.Any() && forks.Any())
            {
                int currKnife = knives.Peek();
                int currFork = forks.Peek();

                if (currKnife > currFork)
                {
                    createdSets.Add(knives.Pop() + forks.Dequeue());
                }
                if (currFork > currKnife)
                {
                    knives.Pop();
                    continue;
                }
                if (currFork == currKnife)
                {
                    forks.Dequeue();
                    knives.Push(knives.Pop() + 1);
                }
            }

            Console.WriteLine($"The biggest set is: {createdSets.Max()}");
            Console.WriteLine(string.Join(" ", createdSets));
        }
    }
}
