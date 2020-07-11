using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Translate"))
                {
                    char ch = char.Parse(splitArgs[1]);
                    char replacement = char.Parse(splitArgs[2]);

                    text = text.Replace(ch, replacement);
                    Console.WriteLine(text);
                }

                if (command.Contains("Includes"))
                {
                    string str = splitArgs[1];

                    if (text.Contains(str))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                if (command.Contains("Start"))
                {
                    string str = splitArgs[1];
                    int indexOfStr = text.IndexOf(str);

                    if (indexOfStr == 0)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                if (command.Contains("Lowercase"))
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }

                if (command.Contains("FindIndex"))
                {
                    char ch = char.Parse(splitArgs[1]);

                    int lastIndexOfCh = text.LastIndexOf(ch);
                    Console.WriteLine(lastIndexOfCh);
                }

                if (command.Contains("Remove"))
                {
                    int startIndex = int.Parse(splitArgs[1]);
                    int count = int.Parse(splitArgs[2]);

                    text = text.Remove(startIndex, count);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
