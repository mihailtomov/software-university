using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\*|@)([A-Z][a-z]{2,})\1: [[]([A-Za-z]+)[\]][|][[]([A-Za-z]+)[\]][|][[]([A-Za-z]+)[\]][|]$";

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    StringBuilder sb = new StringBuilder();

                    for (int j = 3; j <= 5; j++)
                    {
                        sb.Append((int)char.Parse(match.Groups[j].Value));
                        sb.Append(" ");
                    }

                    Console.WriteLine($"{tag}: {string.Join(" ", sb)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
