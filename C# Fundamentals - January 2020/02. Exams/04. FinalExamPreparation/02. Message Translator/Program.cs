using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[!](?<command>[A-Z][a-z]{2,})[!]:[[](?<message>[A-Za-z]{8,})[\]]";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string command = match.Groups["command"].Value;
                    string message = match.Groups["message"].Value;

                    string[] result = new string[message.Length];

                    for (int j = 0; j < message.Length; j++)
                    {
                        result[j] += (int)message[j];
                    }

                    Console.WriteLine($"{command}: {string.Join(" ", result)}");
                }

                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
