using System;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(.+?)[>](\d{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})[<]\1";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string encryptedPassword = "";

                    for (int j = 2; j <= 5; j++)
                    {
                        encryptedPassword += match.Groups[j].Value;
                    }

                    Console.WriteLine($"Password: {encryptedPassword}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
