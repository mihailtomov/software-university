using System;
using System.Collections.Generic;
using System.Linq;

namespace Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine().Split('>').Select(int.Parse).ToList();
            List<int> warship = Console.ReadLine().Split('>').Select(int.Parse).ToList();

            int maximumHealth = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Retire")
            {
                string[] splitted = command.Split();

                if (splitted[0] == "Fire")
                {
                    int index = int.Parse(splitted[1]);
                    int damage = int.Parse(splitted[2]);

                    if (index >= 0 && index < warship.Count)
                    {
                        warship[index] -= damage;

                        if (warship[index] <= 0)
                        {
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }
                    }
                }

                if (splitted[0] == "Defend")
                {
                    int startIndex = int.Parse(splitted[1]);
                    int endIndex = int.Parse(splitted[2]);
                    int damage = int.Parse(splitted[3]);

                    if (startIndex >= 0 && startIndex <= endIndex && endIndex < pirateShip.Count)
                    {
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            pirateShip[i] -= damage;

                            if (pirateShip[i] <= 0)
                            {
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }
                        }
                    }
                }

                if (splitted[0] == "Repair")
                {
                    int index = int.Parse(splitted[1]);
                    int health = int.Parse(splitted[2]);

                    if (index >= 0 && index < pirateShip.Count)
                    {
                        if (pirateShip[index] + health < maximumHealth)
                        {
                            pirateShip[index] += health;
                        }
                        else
                        {
                            pirateShip[index] = maximumHealth;
                        }
                    }
                }

                if (splitted[0] == "Status")
                {
                    int count = 0;
                    double repairThreshold = 0.2 * maximumHealth;

                    for (int i = 0; i < pirateShip.Count; i++)
                    {
                        if (pirateShip[i] < repairThreshold)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"{count} sections need repair.");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");
        }
    }
}
