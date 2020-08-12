using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Hero_Recruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroes = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Enroll"))
                {
                    string heroName = splitArgs[1];

                    if (!heroes.ContainsKey(heroName))
                    {
                        heroes[heroName] = new List<string>();
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                }

                if (command.Contains("Learn"))
                {
                    string heroName = splitArgs[1];
                    string spellName = splitArgs[2];

                    if (heroes.ContainsKey(heroName) && !heroes[heroName].Contains(spellName))
                    {
                        heroes[heroName].Add(spellName);
                    }
                    else if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} has already learnt {spellName}.");
                    }
                }

                if (command.Contains("Unlearn"))
                {
                    string heroName = splitArgs[1];
                    string spellName = splitArgs[2];

                    if (heroes.ContainsKey(heroName) && heroes[heroName].Contains(spellName))
                    {
                        heroes[heroName].Remove(spellName);
                    }
                    else if (!heroes.ContainsKey(heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else if (!heroes[heroName].Contains(spellName))
                    {
                        Console.WriteLine($"{heroName} doesn't know {spellName}.");
                    }
                }
            }

            heroes = heroes
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Heroes: ");

            foreach (var hero in heroes)
            {
                string heroName = hero.Key;
                List<string> listOfSpells = hero.Value;

                Console.Write($"== {heroName}: ");
                Console.Write(string.Join(", ", listOfSpells));
                Console.WriteLine();
            }
        }
    }
}
