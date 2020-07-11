using System;
using System.Collections.Generic;
using System.Linq;

namespace Treasure_Hunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> initialChest = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Yohoho!")
            {
                string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (splitted[0] == "Loot") 
                {
                    for (int i = 1; i < splitted.Length; i++)
                    {
                        if (!initialChest.Contains(splitted[i]))
                        {
                            initialChest.Insert(0, splitted[i]);
                        }
                    }
                }

                if (splitted[0] == "Drop")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < initialChest.Count)
                    {
                        string loot = initialChest[index];
                        initialChest.Remove(initialChest[index]);
                        initialChest.Add(loot);
                    }
                }

                if (splitted[0] == "Steal")
                {
                    int count = int.Parse(splitted[1]);

                    if (initialChest.Count <= count)
                    {
                        Console.WriteLine(string.Join(", ", initialChest));

                        initialChest.Clear();
                    }
                    else
                    {
                        List<string> temp = new List<string>();
                        for (int i = 0; i < count; i++)
                        {
                            temp.Insert(0, initialChest[initialChest.Count - 1]);
                            initialChest.RemoveAt(initialChest.Count - 1);
                        }

                        Console.WriteLine(string.Join(", ", temp));
                    }
                }
                    command = Console.ReadLine();
            }

            double allItemsLength = 0;

            for (int i = 0; i < initialChest.Count; i++)
            {
                allItemsLength += initialChest[i].Length;
            }

            double averageGain = allItemsLength / initialChest.Count;

            if (initialChest.Count > 0)
            {
                Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
            }

            else
            {
                Console.WriteLine("Failed treasure hunt.");
            }
        }
    }
}
