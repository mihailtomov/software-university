using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Nikulden_s_meals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();

            string command;
            int unlikedMealsCount = 0;

            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] splitArgs = command.Split('-');

                if (command.Contains("Like"))
                {
                    string guest = splitArgs[1];
                    string meal = splitArgs[2];

                    if (!guests.ContainsKey(guest))
                    {
                        guests[guest] = new List<string>();
                    }

                    if (!guests[guest].Contains(meal))
                    {
                        guests[guest].Add(meal);
                    }
                }

                if (command.Contains("Unlike"))
                {
                    string guest = splitArgs[1];
                    string meal = splitArgs[2];

                    if (guests.ContainsKey(guest))
                    {
                        if (guests[guest].Contains(meal))
                        {
                            guests[guest].Remove(meal);
                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                            unlikedMealsCount++;
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                    }

                    else
                    {
                        Console.WriteLine($"{guest} is not at the party.");
                    }
                }
            }

            guests = guests
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var guest in guests)
            {
                string guestName = guest.Key;
                List<string> mealsList = guest.Value;

                Console.Write($"{guestName}: ");

                Console.Write($"{string.Join(", ", mealsList)}");
                Console.WriteLine();
            }

            Console.WriteLine($"Unliked meals: {unlikedMealsCount}");
        }
    }
}
