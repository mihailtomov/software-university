using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[U][$](?<username>[A-Z][a-z]{2,})[U][$][P][@][$](?<password>[A-Za-z]{5,}\d+)[P][@][$]";

            int n = int.Parse(Console.ReadLine());

            int successfulRegistrationsCount = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    successfulRegistrationsCount++;

                    string username = match.Groups["username"].Value;
                    string password = match.Groups["password"].Value;

                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {username}, Password: {password}");
                }

                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
