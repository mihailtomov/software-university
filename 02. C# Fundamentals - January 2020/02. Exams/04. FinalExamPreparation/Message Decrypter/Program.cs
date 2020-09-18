using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^([$]|[%])([A-Z][a-z]{2,})\1: [[](\d+)[\]][|][[](\d+)[\]][|][[](\d+)[\]][|]$";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    string decryptedMessage = "";

                    for (int j = 3; j <= 5; j++)
                    {
                        decryptedMessage += (char)int.Parse(match.Groups[j].Value);
                    }

                    Console.WriteLine($"{tag}: {decryptedMessage}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
