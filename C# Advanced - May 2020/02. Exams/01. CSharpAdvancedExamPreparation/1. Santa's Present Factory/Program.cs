using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var materialsNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var magicNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> materials = new Stack<int>(materialsNums);
            Queue<int> magic = new Queue<int>(magicNums);

            SortedDictionary<string, int> craftedToys = new SortedDictionary<string, int>();

            while (materials.Any() && magic.Any())
            {
                int magicLevel = materials.Peek() * magic.Peek();

                if (magicLevel == 150)
                {
                    if (!craftedToys.ContainsKey("Doll"))
                    {
                        craftedToys["Doll"] = 0;
                    }
                    craftedToys["Doll"]++;

                    materials.Pop();
                    magic.Dequeue();
                }
                else if (magicLevel == 250)
                {
                    if (!craftedToys.ContainsKey("Wooden train"))
                    {
                        craftedToys["Wooden train"] = 0;
                    }
                    craftedToys["Wooden train"]++;

                    materials.Pop();
                    magic.Dequeue();
                }
                else if (magicLevel == 300)
                {
                    if (!craftedToys.ContainsKey("Teddy bear")) 
                    {
                        craftedToys["Teddy bear"] = 0;
                    }
                    craftedToys["Teddy bear"]++;

                    materials.Pop();
                    magic.Dequeue();
                }
                else if (magicLevel == 400)
                {
                    if (!craftedToys.ContainsKey("Bicycle"))
                    {
                        craftedToys["Bicycle"] = 0;
                    }
                    craftedToys["Bicycle"]++;

                    materials.Pop();
                    magic.Dequeue();
                }
                else if (magicLevel > 0)
                {
                    magic.Dequeue();
                    materials.Push(materials.Pop() + 15);
                }

                if (magicLevel < 0)
                {
                    int sum = materials.Pop() + magic.Dequeue();
                    materials.Push(sum);
                }

                if (materials.Any() && magic.Any())
                {
                    if (materials.Peek() == 0)
                    {
                        materials.Pop();
                    }
                    if (magic.Peek() == 0)
                    {
                        magic.Dequeue();
                    }
                }             
            }

            if ((craftedToys.ContainsKey("Doll") && craftedToys.ContainsKey("Wooden train"))
                || (craftedToys.ContainsKey("Teddy bear") && craftedToys.ContainsKey("Bicycle")))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (materials.Any())
            {
                Console.WriteLine("Materials left: " + string.Join(", ", materials));
            }
            if (magic.Any())
            {
                Console.WriteLine("Magic left: " + string.Join(", ", magic));
            }

            foreach (var item in craftedToys)
            {
                string toyName = item.Key;
                int amount = item.Value;

                Console.WriteLine($"{toyName}: {amount}");
            }
        }
    }
}
