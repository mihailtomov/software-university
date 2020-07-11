using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> people = new Dictionary<string, int[]>();

            string command;

            while ((command = Console.ReadLine()) != "Results")
            {
                string[] splitArgs = command.Split(':', StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("Add"))
                {
                    string personName = splitArgs[1];
                    int health = int.Parse(splitArgs[2]);
                    int energy = int.Parse(splitArgs[3]);

                    if (!people.ContainsKey(personName))
                    {
                        people[personName] = new int[] { health, energy };
                    }
                    else
                    {
                        people[personName][0] += health;
                    }
                }

                if (command.Contains("Attack"))
                {
                    string attackerName = splitArgs[1];
                    string defenderName = splitArgs[2];
                    int damage = int.Parse(splitArgs[3]);

                    if (people.ContainsKey(attackerName) && people.ContainsKey(defenderName))
                    {
                        people[defenderName][0] -= damage;

                        if (people[defenderName][0] <= 0)
                        {
                            people.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        people[attackerName][1] -= 1;

                        if (people[attackerName][1] <= 0)
                        {
                            people.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }

                if (command.Contains("Delete"))
                {
                    string username = splitArgs[1];

                    if (people.ContainsKey(username))
                    {
                        people.Remove(username);
                    }

                    if (username == "All")
                    {
                        people.Clear();
                    }
                }
            }

            people = people
                .OrderByDescending(kvp => kvp.Value[0])
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"People count: {people.Count}");

            foreach (var user in people)
            {
                string personName = user.Key;
                int health = user.Value[0];
                int energy = user.Value[1];

                Console.WriteLine($"{personName} - {health} - {energy}");
            }
        }
    }
}
