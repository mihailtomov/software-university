using System;
using System.Text;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Sign up")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Case"))
                {
                    if (splitArgs[1] == "lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }

                if (command.Contains("Reverse"))
                {
                    int startIndex = int.Parse(splitArgs[1]);
                    int endIndex = int.Parse(splitArgs[2]);

                    if (startIndex >= 0 && startIndex < username.Length && endIndex >= 0 && endIndex < username.Length)
                    {
                        string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                        StringBuilder sb = new StringBuilder();

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            sb.Append(substring[i]);
                        }

                        Console.WriteLine(sb);
                    }
                }

                if (command.Contains("Cut"))
                {
                    string substring = splitArgs[1];

                    if (username.Contains(substring))
                    {
                        int index = username.IndexOf(substring);
                        username = username.Remove(index, substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }

                if (command.Contains("Replace"))
                {
                    char ch = char.Parse(splitArgs[1]);
                    username = username.Replace(ch, '*');
                    Console.WriteLine(username);
                }

                if (command.Contains("Check"))
                {
                    char ch = char.Parse(splitArgs[1]);

                    if (username.Contains(ch))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {ch}.");
                    }
                }
            }
        }
    }
}
