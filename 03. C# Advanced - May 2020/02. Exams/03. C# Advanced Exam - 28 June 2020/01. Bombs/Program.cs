using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int[] bombCasings = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> effect = new Queue<int>(bombEffects);
            Stack<int> casing = new Stack<int>(bombCasings);

            SortedDictionary<string, int> createdBombs = new SortedDictionary<string, int>()
            {
                { "Datura Bombs", 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0 }
            };

            bool enoughDatura = false;
            bool enoughCherry = false;
            bool enoughSmoke = false;
            bool pouchFilled = false;

            while (effect.Any() && casing.Any())
            {
                if (enoughDatura == true && enoughCherry == true && enoughSmoke == true)
                {
                    pouchFilled = true;
                    break;
                }

                int currEffect = effect.Peek();
                int currCasing = casing.Peek();

                if (currEffect + currCasing == 40)
                {
                    createdBombs["Datura Bombs"]++;

                    if (createdBombs["Datura Bombs"] == 3)
                    {
                        enoughDatura = true;
                    }

                    effect.Dequeue();
                    casing.Pop();
                }
                else if (currEffect + currCasing == 60)
                {
                    createdBombs["Cherry Bombs"]++;

                    if (createdBombs["Cherry Bombs"] == 3)
                    {
                        enoughCherry = true;
                    }

                    effect.Dequeue();
                    casing.Pop();
                }
                else if (currEffect + currCasing == 120)
                {
                    createdBombs["Smoke Decoy Bombs"]++;

                    if (createdBombs["Smoke Decoy Bombs"] == 3)
                    {
                        enoughSmoke = true;
                    }

                    effect.Dequeue();
                    casing.Pop();
                }
                else
                {
                    casing.Push(casing.Pop() - 5);
                }

                if (enoughDatura == true && enoughCherry == true && enoughSmoke == true)
                {
                    pouchFilled = true;
                    break;
                }
            }

            if (pouchFilled == true)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effect.Any())
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ", effect));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (casing.Any())
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", casing));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var kvp in createdBombs)
            {
                string bomb = kvp.Key;
                int count = kvp.Value;

                Console.WriteLine($"{bomb}: {count}");
            }
        }
    }
}
