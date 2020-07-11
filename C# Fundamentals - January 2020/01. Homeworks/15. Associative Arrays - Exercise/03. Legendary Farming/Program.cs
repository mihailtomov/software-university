using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> junk = new Dictionary<string, int>();

            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;
            keyMaterials["motes"] = 0;

            bool isEnough = false;

            while (true)
            {
                if (isEnough == true)
                {
                    break;
                }

                string input = Console.ReadLine().ToLower();

                string[] argsMaterials = input.Split();

                for (int i = 0; i < argsMaterials.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        int quantity = int.Parse(argsMaterials[i]);
                        string material = argsMaterials[i + 1];

                        if (material == "shards" || material == "fragments" || material == "motes")
                        {                         
                            keyMaterials[material] += quantity;

                            if (keyMaterials[material] >= 250)
                            {
                                keyMaterials[material] -= 250;

                                string item;

                                if (material == "shards")
                                {
                                    item = "Shadowmourne";
                                }

                                else if (material == "fragments")
                                {
                                    item = "Valanyr";
                                }

                                else
                                {
                                    item = "Dragonwrath";
                                }

                                Console.WriteLine($"{item} obtained!");
                                isEnough = true;
                                break;
                            }
                        }

                        else
                        {
                            if (!junk.ContainsKey(material))
                            {
                                junk[material] = 0;
                            }

                            junk[material] += quantity;
                        }
                    }
                }
            }

            Dictionary<string, int> sortedMaterials = keyMaterials
                .OrderBy(kvp => kvp.Key)
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            junk = junk.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var item in sortedMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junk)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
