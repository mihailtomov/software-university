using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> heroes = new Dictionary<string, int[]>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string currentHero = Console.ReadLine();
                string[] splitArgs = currentHero.Split();

                string heroName = splitArgs[0];
                int health = int.Parse(splitArgs[1]);
                int mana = int.Parse(splitArgs[2]);

                if (!heroes.ContainsKey(heroName))
                {
                    heroes[heroName] = new int[] { health, mana };
                }
            }

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitArgs = command.Split(" - ");

                if (command.Contains("CastSpell"))
                {
                    string heroName = splitArgs[1];
                    int manaNeeded = int.Parse(splitArgs[2]);
                    string spellName = splitArgs[3];

                    if (heroes[heroName][1] >= manaNeeded)
                    {
                        heroes[heroName][1] -= manaNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }

                if (command.Contains("TakeDamage"))
                {
                    string heroName = splitArgs[1];
                    int damage = int.Parse(splitArgs[2]);
                    string attacker = splitArgs[3];

                    heroes[heroName][0] -= damage;

                    if (heroes[heroName][0] > 0)
                    {
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName][0]} HP left!");
                    }
                    else
                    {
                        heroes.Remove(heroName);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }

                if (command.Contains("Recharge"))
                {
                    string heroName = splitArgs[1];
                    int amount = int.Parse(splitArgs[2]);

                    int startingAmount = heroes[heroName][1];
                    int amountRecovered = 0;

                    heroes[heroName][1] += amount;

                    if (heroes[heroName][1] > 200)
                    {
                        heroes[heroName][1] = 200;
                        amountRecovered = heroes[heroName][1] - startingAmount;
                    }
                    else
                    {
                        amountRecovered = amount;
                    }

                    Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
                }

                if (command.Contains("Heal"))
                {
                    string heroName = splitArgs[1];
                    int amount = int.Parse(splitArgs[2]);

                    int startingAmount = heroes[heroName][0];
                    int amountRecovered = 0;

                    heroes[heroName][0] += amount;

                    if (heroes[heroName][0] > 100)
                    {
                        heroes[heroName][0] = 100;
                        amountRecovered = heroes[heroName][0] - startingAmount;
                    }
                    else
                    {
                        amountRecovered = amount;
                    }

                    Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
                }
            }

            heroes = heroes
                .OrderByDescending(kvp => kvp.Value[0])
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var hero in heroes)
            {
                string heroName = hero.Key;
                int currentHealth = hero.Value[0];
                int currentMana = hero.Value[1];

                Console.WriteLine(heroName);
                Console.WriteLine($"  HP: {currentHealth}");
                Console.WriteLine($"  MP: {currentMana}");
            }
        }
    }
}
