using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] filledBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> cups = new Queue<int>(cupsCapacity);
            Stack<int> bottles = new Stack<int>(filledBottles);

            int wastedLittersOfWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currCup = cups.Peek();
                int currBottle = bottles.Peek();

                if (currBottle >= currCup)
                {
                    currCup -= currBottle;
                    wastedLittersOfWater += Math.Abs(currCup);
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    while (currCup > 0 && bottles.Any())
                    { 
                        currCup -= currBottle;
                        bottles.Pop();

                        if (bottles.Any())
                        {
                            currBottle = bottles.Peek();
                        }
                    }
                    if (currCup <= 0)
                    {
                        cups.Dequeue();
                        wastedLittersOfWater += Math.Abs(currCup);
                    }
                    else
                    {
                        break;
                    }
                }              
            }

            if (!cups.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
