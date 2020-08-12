using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> clothes = 
                new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string colour = input[0];
                string items = input[1];
                string[] splittedItems = items.Split(",");

                if (!clothes.ContainsKey(colour))
                {
                    clothes[colour] = new Dictionary<string, int>();

                    for (int j = 0; j < splittedItems.Length; j++)
                    {
                        string currItem = splittedItems[j];

                        if (!clothes[colour].ContainsKey(currItem))
                        {
                            clothes[colour][currItem] = 1;
                        }
                        else
                        {
                            clothes[colour][currItem]++;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < splittedItems.Length; j++)
                    {
                        string currItem = splittedItems[j];

                        if (!clothes[colour].ContainsKey(currItem))
                        {
                            clothes[colour][currItem] = 1;
                        }
                        else
                        {
                            clothes[colour][currItem]++;
                        }
                    }
                }
            }

            string[] itemData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string colourOfItem = itemData[0];
            string theItem = itemData[1];

            foreach (var cloth in clothes)
            {
                string colour = cloth.Key;
                Dictionary<string, int> items = cloth.Value;

                Console.WriteLine($"{colour} clothes:");

                foreach (var item in items)
                {
                    string currItem = item.Key;
                    int count = item.Value;

                    if (colourOfItem == colour && theItem == currItem)
                    {
                        Console.WriteLine($"* {currItem} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {currItem} - {count}");
                    }
                }
            }
        }
    }
}
