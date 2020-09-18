using System;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "For Azeroth")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("GladiatorStance"))
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }

                else if (command.Contains("DefensiveStance"))
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }

                else if (command.Contains("Dispel"))
                {
                    int index = int.Parse(splitArgs[1]);
                    char letter = char.Parse(splitArgs[2]);

                    if (index >= 0 && index < input.Length)
                    {
                        char[] temp = input.ToCharArray();
                        temp[index] = letter;

                        input = new string(temp);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }

                else if (command.Contains("Target Change"))
                {
                    string substring = splitArgs[2];
                    string secondSubstring = splitArgs[3];

                    if (input.Contains(substring))
                    {
                        input = input.Replace(substring, secondSubstring);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                    }
                }

                else if (command.Contains("Target Remove"))
                {
                    string substring = splitArgs[2];
                    int index = input.IndexOf(substring);

                    if (input.Contains(substring))
                    {
                        input = input.Remove(index, substring.Length);
                        Console.WriteLine(input);
                    }
                    else
                    {
                        Console.WriteLine("Command doesn't exist!");
                    }
                }

                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
            }
        }
    }
}
