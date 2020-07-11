using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> info = new Dictionary<string, List<string>>();

            string command;

            while((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split("->");

                if (command.Contains("Add"))
                {
                    string road = splitArgs[1];
                    string racer = splitArgs[2];

                    if (!info.ContainsKey(road))
                    {
                        info[road] = new List<string>();
                        info[road].Add(racer);
                    }
                    else
                    {
                        info[road].Add(racer);
                    }
                }

                if (command.Contains("Move"))
                {
                    string currentRoad = splitArgs[1];
                    string racer = splitArgs[2];
                    string nextRoad = splitArgs[3];

                    if (info[currentRoad].Contains(racer))
                    {
                        info[currentRoad].Remove(racer);
                        info[nextRoad].Add(racer);
                    }
                }

                if (command.Contains("Close"))
                {
                    string road = splitArgs[1];

                    if (info.ContainsKey(road))
                    {
                        info.Remove(road);
                    }
                }
            }

            info = info
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Practice sessions:");

            foreach (var road in info)
            {
                string currentRoad = road.Key;
                List<string> racers = road.Value;

                Console.WriteLine(currentRoad);

                foreach (var racer in racers)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
