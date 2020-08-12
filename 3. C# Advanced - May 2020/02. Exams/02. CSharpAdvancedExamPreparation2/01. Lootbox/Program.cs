using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var nums2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> boxOne = new Queue<int>(nums1);
            Stack<int> boxTwo = new Stack<int>(nums2);

            List<int> claimedItems = new List<int>();

            while (boxOne.Any() && boxTwo.Any())
            {
                int summedItem = boxOne.Peek() + boxTwo.Peek();

                if (summedItem % 2 == 0)
                {
                    claimedItems.Add(summedItem);
                    boxOne.Dequeue();
                    boxTwo.Pop();
                }
                else
                {
                    int lastItem = boxTwo.Pop();
                    boxOne.Enqueue(lastItem);
                }
            }

            if (boxOne.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int claimedItemsSum = claimedItems.Sum();

            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }
        }
    }
}
