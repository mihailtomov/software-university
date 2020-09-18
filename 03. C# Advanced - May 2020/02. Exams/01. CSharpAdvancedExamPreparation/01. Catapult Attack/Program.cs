using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Catapult_Attack
{
    class Program
    {
        static void Main(string[] args)
        {
            int pilesOfRocks = int.Parse(Console.ReadLine());
            int[] fortressWalls = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> walls = new Stack<int>(fortressWalls.Reverse());
            Stack<int> rocks = new Stack<int>();
            int counter = 1;

            while (counter <= pilesOfRocks)
            {
                if (!walls.Any())
                {
                    break;
                }

                int[] pile = Console.ReadLine()
                   .Split()
                   .Select(int.Parse)
                   .ToArray();

                rocks = new Stack<int>(pile);

                if (counter % 3 == 0)
                {
                    int extraWall = int.Parse(Console.ReadLine());
                    List<int> temp = walls.ToList();
                    temp.Add(extraWall);
                    temp.Reverse();
                    walls = new Stack<int>(temp);
                }

                while (rocks.Any() && walls.Any())
                {
                    if (rocks.Peek() > walls.Peek())
                    {
                        rocks.Push(rocks.Pop() - walls.Pop());
                        continue;
                    }
                    if (walls.Peek() > rocks.Peek())
                    {
                        walls.Push(walls.Pop() - rocks.Pop());
                        continue;
                    }
                    if (walls.Peek() == rocks.Peek())
                    {
                        walls.Pop();
                        rocks.Pop();
                    }
                }

                counter++;
            }
                
            if (rocks.Any())
            {
                Console.WriteLine("Rocks left: " + string.Join(", ", rocks));
            }
            if (walls.Any())
            {
                Console.WriteLine("Walls left: " + string.Join(", ", walls));
            }
        }
    }
}
