using System;

namespace String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Done")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Change"))
                {
                    char oldCh = char.Parse(splitArgs[1]);
                    char replacement = char.Parse(splitArgs[2]);

                    text = text.Replace(oldCh, replacement);
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

                if (command.Contains("End"))
                {
                    string str = splitArgs[1];
                    int indexOfStr = text.IndexOf(str);

                    if (indexOfStr + str.Length == text.Length)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                if (command.Contains("Uppercase"))
                {
                    text = text.ToUpper();
                    Console.WriteLine(text);
                }

                if (command.Contains("FindIndex"))
                {
                    char ch = char.Parse(splitArgs[1]);
                    int indexOfCh = text.IndexOf(ch);
                    Console.WriteLine(indexOfCh);
                }

                if (command.Contains("Cut"))
                {
                    int startIndex = int.Parse(splitArgs[1]);
                    int length = int.Parse(splitArgs[2]);

                    text = text.Remove(0, startIndex);
                    text = text.Remove(length, text.Length - length);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
