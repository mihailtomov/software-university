using System;
using System.Text;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string command;

            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] splitArgs = command.Split(":|:");

                if (command.Contains("InsertSpace"))
                {
                    int index = int.Parse(splitArgs[1]);

                    message = message.Insert(index, " ");
                    Console.WriteLine(message);
                }

                if (command.Contains("Reverse"))
                {
                    string substring = splitArgs[1];

                    if (message.Contains(substring))
                    {
                        int indexOfSubstring = message.IndexOf(substring);
                        message = message.Remove(indexOfSubstring, substring.Length);

                        StringBuilder reversedSubstring = new StringBuilder();

                        for (int i = substring.Length - 1; i >= 0; i--)
                        {
                            reversedSubstring.Append(substring[i]);
                        }

                        message += reversedSubstring;
                        Console.WriteLine(message);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }

                if (command.Contains("ChangeAll"))
                {
                    string substring = splitArgs[1];
                    string replacement = splitArgs[2];

                    message = message.Replace(substring, replacement);
                    Console.WriteLine(message);
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
