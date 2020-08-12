using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> clients = new Queue<string>();

            string name;

            while ((name = Console.ReadLine()) != "End")
            {
                if (name != "Paid")
                {
                    clients.Enqueue(name);
                }
                else
                {
                    int count = clients.Count;

                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(clients.Dequeue());
                    }
                }
            }

            Console.WriteLine($"{clients.Count} people remaining.");
        }
    }
}
