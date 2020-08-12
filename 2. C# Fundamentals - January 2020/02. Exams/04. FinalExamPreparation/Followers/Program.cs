using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> followers = new Dictionary<string, int[]>();

            string command;

            while ((command = Console.ReadLine()) != "Log out")
            {
                string[] splitArgs = command.Split(": ");

                if (command.Contains("New"))
                {
                    string username = splitArgs[1];

                    if (!followers.ContainsKey(username))
                    {
                        followers[username] = new int[] { 0, 0 };
                    }
                }

                if (command.Contains("Like"))
                {
                    string username = splitArgs[1];
                    int count = int.Parse(splitArgs[2]);

                    if (!followers.ContainsKey(username))
                    {
                        followers[username] = new int[] { count, 0 };
                    }
                    else
                    {
                        followers[username][0] += count;
                    }
                }

                if (command.Contains("Comment"))
                {
                    string username = splitArgs[1];

                    if (!followers.ContainsKey(username))
                    {
                        followers[username] = new int[] { 0, 1 };
                    }
                    else
                    {
                        followers[username][1] += 1;
                    }
                }

                if (command.Contains("Blocked"))
                {
                    string username = splitArgs[1];

                    if (followers.ContainsKey(username))
                    {
                        followers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            followers = followers
                .OrderByDescending(kvp => kvp.Value[0])
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"{followers.Count} followers");

            foreach (var username in followers)
            {
                Console.WriteLine($"{username.Key}: {username.Value.Sum()}");
            }
        }
    }
}
