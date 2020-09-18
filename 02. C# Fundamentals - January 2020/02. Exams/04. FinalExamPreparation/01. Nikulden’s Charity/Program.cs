using System;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Replace"))
                {
                    char currChar = char.Parse(splitArgs[1]);
                    char newChar = char.Parse(splitArgs[2]);

                    text = text.Replace(currChar, newChar);
                    Console.WriteLine(text);
                }

                if (command.Contains("Cut"))
                {
                    int startIndex = int.Parse(splitArgs[1]);
                    int endIndex = int.Parse(splitArgs[2]);

                    if ((startIndex >= 0 && startIndex < text.Length) && (endIndex >= 0 && endIndex < text.Length))
                    {
                        int count = endIndex - startIndex + 1;
                        string substring = text.Substring(startIndex, count);
                        text = text.Remove(startIndex, substring.Length);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }

                if (command.Contains("Upper"))
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }

                if (command.Contains("Lower"))
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }

                if (command.Contains("Check"))
                {
                    string stringToCheck = splitArgs[1];

                    if (text.Contains(stringToCheck))
                    {
                        Console.WriteLine($"Message contains {stringToCheck}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {stringToCheck}");
                    }
                }

                if (command.Contains("Sum"))
                {
                    int startIndex = int.Parse(splitArgs[1]);
                    int endIndex = int.Parse(splitArgs[2]);

                    if ((startIndex >= 0 && startIndex < text.Length) && (endIndex >= 0 && endIndex < text.Length))
                    {
                        string substring = text.Substring(startIndex, endIndex - startIndex + 1);
                        int sum = 0;

                        for (int i = 0; i < substring.Length; i++)
                        {
                            sum += substring[i];
                        }

                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                }
            }
        }
    }
}
