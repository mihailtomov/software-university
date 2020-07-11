using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> usersBook = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] inputArgs = input
                    .Split(new string[] {" -> ", " | "}, StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains('|'))
                {
                    string forceSide = inputArgs[0];
                    string forceUser = inputArgs[1];

                    if (!usersBook.ContainsKey(forceSide))
                    {
                        usersBook[forceSide] = new List<string>();
                    }

                    bool ifExists = false;

                    foreach (var user in usersBook.Values)
                    {
                        if (user.Contains(forceUser))
                        {
                            ifExists = true;
                            break;
                        }
                    }

                    if (ifExists == false)
                    {
                        usersBook[forceSide].Add(forceUser);
                    }
                }

                if (input.Contains('-'))
                {
                    string forceUser = inputArgs[0];
                    string forceSide = inputArgs[1];

                    bool ifExists = false;

                    foreach (var user in usersBook.Values)
                    {
                        if (user.Contains(forceUser))
                        {
                            ifExists = true;
                            user.Remove(forceUser);
                            break;
                        }
                    }

                    if (ifExists == true)
                    {
                        usersBook[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                    else
                    {
                        usersBook[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                }
            }

            usersBook = usersBook
                    .OrderByDescending(kvp => kvp.Value.Count)
                    .OrderBy(kvp => kvp.Key)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var kvp in usersBook)
            {
                string forceSide = kvp.Key;
                List<string> forceUsers = kvp.Value.OrderBy(l => l).ToList();
                int usersCount = kvp.Value.Count;

                if (usersCount > 0)
                {
                    Console.WriteLine($"Side: {forceSide}, Members: {usersCount}");

                    foreach (var user in forceUsers)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
