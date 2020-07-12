using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var maleIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var femaleIntegers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> males = new Stack<int>(maleIntegers);
            Queue<int> females = new Queue<int>(femaleIntegers);

            int matchesCount = 0;

            while (males.Any() && females.Any())
            {
                if (males.Peek() <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (females.Peek() <= 0)
                {
                    females.Dequeue();
                    continue;
                }

                if (males.Peek() % 25 == 0)
                {
                    males.Pop();

                    if (males.Any())
                    {
                        males.Pop();
                        continue;
                    }
                }
                if (females.Peek() % 25 == 0)
                {
                    females.Dequeue();

                    if (females.Any())
                    {
                        females.Dequeue();
                        continue;
                    }
                }

                if (males.Peek() == females.Peek())
                {
                    matchesCount++;

                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    int decrease = males.Pop() - 2;
                    males.Push(decrease);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");

            if (males.Any())
            {
                Console.WriteLine("Males left: " + string.Join(", ", males));
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Any())
            {
                Console.WriteLine("Females left: " + string.Join(", ", females));
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
