using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] splitArgs = command.Split("->");

                if (command.Contains("Add"))
                {
                    string username = splitArgs[1];

                    if (users.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else
                    {
                        users[username] = new List<string>();
                    }
                }

                if (command.Contains("Send"))
                {
                    string username = splitArgs[1];
                    string email = splitArgs[2];

                    if (users.ContainsKey(username))
                    {
                        users[username].Add(email);
                    }
                }

                if (command.Contains("Delete"))
                {
                    string username = splitArgs[1];

                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                }
            }

            users = users
                .OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users)
            {
                string username = user.Key;
                List<string> emails = user.Value;

                Console.WriteLine($"{username}");

                foreach (var email in emails)
                {
                    Console.WriteLine($" - {email}");
                }
            }
        }
    }
}
