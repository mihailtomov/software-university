using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy_Squad
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> frogs = Console.ReadLine().Split().ToList();

            while (true)
            {
                string command = Console.ReadLine();

                string[] splitted = command.Split();

                if (splitted[0] == "Join")
                {
                    string name = splitted[1];

                    frogs.Add(name);
                }

                if (splitted[0] == "Jump")
                {
                    string name = splitted[1];
                    int index = int.Parse(splitted[2]);

                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.Insert(index, name);
                    }
                }

                if (splitted[0] == "Dive")
                {
                    int index = int.Parse(splitted[1]);

                    if (index >= 0 && index < frogs.Count)
                    {
                        frogs.RemoveAt(index);
                    }
                }

                if (splitted[0] == "First")
                {
                    int count = int.Parse(splitted[1]);

                    if (count < frogs.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write($"{frogs[i]} ");
                        }

                        Console.WriteLine();
                    }

                    else
                    {
                        Console.WriteLine(string.Join(" ", frogs));
                    }
                }

                if (splitted[0] == "Last")
                {
                    int count = int.Parse(splitted[1]);

                    if (count < frogs.Count)
                    {
                        for (int i = frogs.Count - count; i < frogs.Count; i++)
                        {
                            Console.Write($"{frogs[i]} ");
                        }

                        Console.WriteLine();
                    }

                    else
                    {
                        Console.WriteLine(string.Join(" ", frogs));
                    }
                }

                if (splitted[0] == "Print")
                {
                    if (splitted[1] == "Normal")
                    {
                        Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                        return;
                    }

                    if (splitted[1] == "Reversed")
                    {
                        frogs.Reverse();
                        Console.WriteLine($"Frogs: {string.Join(" ", frogs)}");
                        return;
                    }
                }
            }
        }
    }
}
