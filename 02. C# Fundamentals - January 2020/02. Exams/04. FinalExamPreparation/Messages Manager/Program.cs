using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> users = new Dictionary<string, int[]>();

            int capacity = int.Parse(Console.ReadLine());

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] splitArgs = command.Split('=');

                if (command.Contains("Add"))
                {
                    string username = splitArgs[1];
                    int sent = int.Parse(splitArgs[2]);
                    int received = int.Parse(splitArgs[3]);

                    if (!users.ContainsKey(username))
                    {
                        users[username] = new int[] { sent, received };
                    }
                }

                if (command.Contains("Message"))
                {
                    string sender = splitArgs[1];
                    string receiver = splitArgs[2];

                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender][0] += 1;
                        users[receiver][1] += 1;

                        if (users[sender][0] + users[sender][1] >= capacity)
                        {
                            users.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (users[receiver][0] + users[receiver][1] >= capacity)
                        {
                            users.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }

                if (command.Contains("Empty"))
                {
                    string username = splitArgs[1];

                    if (username == "All")
                    {
                        users.Clear();
                    }

                    if (users.ContainsKey(username))
                    {
                        users.Remove(username);
                    }
                }
            }

            users = users
                .OrderByDescending(kvp => kvp.Value[1])
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} - {user.Value.Sum()}");
            }
        }
    }
}
