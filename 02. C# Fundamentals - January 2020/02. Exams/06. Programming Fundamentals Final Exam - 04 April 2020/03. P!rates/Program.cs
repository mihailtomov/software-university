using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> cities = new Dictionary<string, int[]>();

            string targets;

            while ((targets = Console.ReadLine()) != "Sail")
            {
                string[] splitArgs = targets.Split("||");

                string town = splitArgs[0];
                int population = int.Parse(splitArgs[1]);
                int gold = int.Parse(splitArgs[2]);

                if (!cities.ContainsKey(town))
                {
                    cities[town] = new int[] { population, gold };
                }
                else
                {
                    cities[town][0] += population;
                    cities[town][1] += gold;
                }
            }

            string events;

            while ((events = Console.ReadLine()) != "End")
            {
                string[] splitArgs = events.Split("=>");

                if (events.Contains("Plunder"))
                {
                    string town = splitArgs[1];
                    int people = int.Parse(splitArgs[2]);
                    int gold = int.Parse(splitArgs[3]);

                    cities[town][0] -= people;
                    cities[town][1] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (cities[town][0] <= 0 || cities[town][1] <= 0)
                    {
                        cities.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }

                if (events.Contains("Prosper"))
                {
                    string town = splitArgs[1];
                    int gold = int.Parse(splitArgs[2]);

                    if (gold >= 0)
                    {
                        cities[town][1] += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {cities[town][1]} gold.");
                    }
                    else
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                }
            }

            if (cities.Count > 0)
            {
                cities = cities
                    .OrderByDescending(kvp => kvp.Value[1])
                    .ThenBy(kvp => kvp.Key)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");

                foreach (var town in cities)
                {
                    string currTown = town.Key;
                    int people = town.Value[0];
                    int gold = town.Value[1];

                    Console.WriteLine($"{currTown} -> Population: {people} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
