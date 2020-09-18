using System;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] splitArgs = command.Split(">>>");

                if (command.Contains("Contains"))
                {
                    string substring = splitArgs[1];

                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"{text} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }

                if (command.Contains("Flip"))
                {
                    int startIndex = int.Parse(splitArgs[2]);
                    int endIndex = int.Parse(splitArgs[3]);

                    string substring = text.Substring(startIndex, endIndex - startIndex);

                    if (splitArgs[1] == "Upper")
                    {
                        string newSubstring = substring.ToUpper();
                        text = text.Replace(substring, newSubstring);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        string newSubstring = substring.ToLower();
                        text = text.Replace(substring, newSubstring);
                        Console.WriteLine(text);
                    }
                }

                if (command.Contains("Slice"))
                {
                    int startIndex = int.Parse(splitArgs[1]);
                    int endIndex = int.Parse(splitArgs[2]);

                    text = text.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(text);
                }
            }

            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
