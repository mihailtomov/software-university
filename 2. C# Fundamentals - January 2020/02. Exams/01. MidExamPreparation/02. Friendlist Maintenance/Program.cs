using System;

namespace _02._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string command = Console.ReadLine();
            int blacklistedNamesCount = 0;
            int lostNamesCount = 0;

            while (command != "Report")
            {
                string[] splitted = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (splitted[0] == "Blacklist")
                {
                    string name = splitted[1];

                    int posOfName = Array.IndexOf(usernames, name);

                    if (posOfName != -1)
                    {
                        usernames[posOfName] = "Blacklisted";
                        blacklistedNamesCount++;
                        Console.WriteLine($"{name} was blacklisted.");
                    }

                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }
                }

                if (splitted[0] == "Error")
                {
                    int index = int.Parse(splitted[1]);

                    if (usernames[index] != "Blacklisted" && usernames[index] != "Lost")
                    {
                        string name = usernames[index];
                        usernames[index] = "Lost";
                        lostNamesCount++;
                        Console.WriteLine($"{name} was lost due to an error.");
                    }
                }

                if (splitted[0] == "Change")
                {
                    int index = int.Parse(splitted[1]);
                    string newName = splitted[2];

                    if (index >= 0 && index < usernames.Length)
                    {
                        string currentName = usernames[index];
                        usernames[index] = newName;
                        Console.WriteLine($"{currentName} changed his username to {newName}.");
                    }
                }

                    command = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {blacklistedNamesCount}");
            Console.WriteLine($"Lost names: {lostNamesCount}");
            Console.WriteLine(string.Join(" ", usernames));
        }
    }
}
