using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Tanks_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> ownedTanks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string command = Console.ReadLine();

                string[] splitted = command.Split(", ");

                if (splitted[0] == "Add")
                {
                    string tankName = splitted[1];

                    if (ownedTanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }

                    else
                    {
                        Console.WriteLine("Tank successfully bought");
                        ownedTanks.Add(tankName);
                    }
                }

                if (splitted[0] == "Remove")
                {
                    string tankName = splitted[1];

                    if (ownedTanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank successfully sold");
                        ownedTanks.Remove(tankName);
                    }

                    else
                    {
                        Console.WriteLine("Tank not found");
                    }
                }

                if (splitted[0] == "Remove At")
                {
                    int index = int.Parse(splitted[1]);

                    if (index < 0 || index > ownedTanks.Count - 1)
                    {
                        Console.WriteLine("Index out of range");
                    }

                    else
                    {
                        ownedTanks.RemoveAt(index);
                        Console.WriteLine("Tank successfully sold");
                    }
                }

                if (splitted[0] == "Insert")
                {
                    int index = int.Parse(splitted[1]);
                    string tankName = splitted[2];

                    if (index < 0 || index > ownedTanks.Count - 1)
                    {
                        Console.WriteLine("Index out of range");
                    }

                    else if (index >= 0 && index < ownedTanks.Count && !ownedTanks.Contains(tankName))
                    {
                        ownedTanks.Insert(index, tankName);
                        Console.WriteLine("Tank successfully bought");
                    }

                    else if (index >= 0 && index < ownedTanks.Count && ownedTanks.Contains(tankName))
                    {
                        Console.WriteLine("Tank is already bought");
                    }
                }

            }

            Console.WriteLine(string.Join(", ", ownedTanks));
        }
    }
}
