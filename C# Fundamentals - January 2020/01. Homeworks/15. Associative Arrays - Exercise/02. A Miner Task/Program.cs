using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ulong> goods = new Dictionary<string, ulong>();

            while (true)
            {
                string resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                ulong quantity = ulong.Parse(Console.ReadLine());

                if (!goods.ContainsKey(resource))
                {
                    goods[resource] = 0;
                }

                goods[resource] += quantity;
            }

            foreach (var kvp in goods)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
