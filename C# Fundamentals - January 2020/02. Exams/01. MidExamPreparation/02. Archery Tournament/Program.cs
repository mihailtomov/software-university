using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split('|').Select(int.Parse).ToList();

            string command = Console.ReadLine();
            int points = 0;

            while (command != "Game over")
            {
                string[] splitted = command.Split('@');

                if (splitted[0] == "Shoot Left")
                {
                    int startIndex = int.Parse(splitted[1]);
                    int length = int.Parse(splitted[2]);

                    if (startIndex >= 0 && startIndex < targets.Count)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            startIndex--;
                            if (startIndex == -1)
                            {
                                startIndex = targets.Count - 1;
                            }
                        }

                        if (targets[startIndex] > 0)
                        {
                            if (targets[startIndex] >= 5)
                            {
                                targets[startIndex] -= 5;
                                points += 5;
                            }

                            else
                            {
                                points += targets[startIndex];
                                targets[startIndex] = 0;
                            }
                        }
                    }
                }

                if (splitted[0] == "Shoot Right")
                {
                    int startIndex = int.Parse(splitted[1]);
                    int length = int.Parse(splitted[2]);

                    if (startIndex >= 0 && startIndex < targets.Count)
                    {
                        for (int i = 0; i < length; i++)
                        {
                            startIndex++;
                            if (startIndex == targets.Count)
                            {
                                startIndex = 0;
                            }
                        }

                        if (targets[startIndex] > 0)
                        {
                            if (targets[startIndex] >= 5)
                            {
                                targets[startIndex] -= 5;
                                points += 5;
                            }

                            else
                            {
                                points += targets[startIndex];
                                targets[startIndex] = 0;
                            }
                        }
                    }
                }

                if (splitted[0] == "Reverse")
                {
                    targets.Reverse();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" - ", targets));
            Console.WriteLine($"Iskren finished the archery tournament with {points} points!");
        }
    }
}
