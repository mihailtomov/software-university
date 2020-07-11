using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitArgs = command.Split();

                if (splitArgs[0] == "Shoot")
                {
                    int index = int.Parse(splitArgs[1]);
                    int power = int.Parse(splitArgs[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets[index] -= power;

                        if (targets[index] <= 0)
                        {
                            targets.Remove(targets[index]);
                        }
                    }
                }

                if (splitArgs[0] == "Add")
                {
                    int index = int.Parse(splitArgs[1]);
                    int value = int.Parse(splitArgs[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }

                if (splitArgs[0] == "Strike")
                {
                    int index = int.Parse(splitArgs[1]);
                    int radius = int.Parse(splitArgs[2]);

                    if ((index >= 0 && index < targets.Count) && (index - radius >= 0 && index + radius < targets.Count))
                    {
                        int countToRemove = 1 + 2 * radius;

                        for (int i = 0; i < countToRemove; i++)
                        {
                            targets.RemoveAt(index - radius);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }

            Console.WriteLine(string.Join("|", targets));
        }
    }
}
