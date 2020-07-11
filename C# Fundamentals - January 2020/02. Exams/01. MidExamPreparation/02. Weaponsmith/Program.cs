using System;

namespace _02._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] particles = Console.ReadLine().Split('|');

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] splitted = command.Split();

                if (splitted[1] == "Left")
                {
                    int index = int.Parse(splitted[2]);

                    if (index > 0 && index < particles.Length)
                    {
                        string temp = particles[index];
                        particles[index] = particles[index - 1];
                        particles[index - 1] = temp;
                    }
                }

                if (splitted[1] == "Right")
                {
                    int index = int.Parse(splitted[2]);

                    if (index >= 0 && index < particles.Length - 1)
                    {
                        string temp = particles[index];
                        particles[index] = particles[index + 1];
                        particles[index + 1] = temp;
                    }
                }

                if (splitted[1] == "Even")
                {
                    for (int i = 0; i < particles.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.Write($"{particles[i]} ");
                        }
                    }

                    Console.WriteLine();
                }

                if (splitted[1] == "Odd")
                {
                    for (int i = 0; i < particles.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            Console.Write($"{particles[i]} ");
                        }
                    }

                    Console.WriteLine();
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {string.Join("", particles)}!");
        }
    }
}
