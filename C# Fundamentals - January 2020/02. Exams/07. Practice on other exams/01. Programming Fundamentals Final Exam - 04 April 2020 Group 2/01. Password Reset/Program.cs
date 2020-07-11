using System;

namespace _01._Password_Reset
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

                if (command.Contains("TakeOdd"))
                {
                    string newRawPassword = "";

                    for (int i = 0; i < text.Length; i++)
                    {
                        char currCh = text[i];

                        if (i % 2 != 0)
                        {
                            newRawPassword += currCh;
                        }
                    }

                    text = text.Replace(text, newRawPassword);

                    Console.WriteLine(text);
                }

                if (command.Contains("Cut"))
                {
                    int index = int.Parse(splitArgs[1]);
                    int length = int.Parse(splitArgs[2]);

                    string substring = text.Substring(index, length);
                    int indexOfSubstring = text.IndexOf(substring);

                    text = text.Remove(indexOfSubstring, substring.Length);
                    Console.WriteLine(text);
                }

                if (command.Contains("Substitute"))
                {
                    string substring = splitArgs[1];
                    string substitute = splitArgs[2];

                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, substitute);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {text}");
        }
    }
}
