using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int[]> vloggerInfo = new Dictionary<string, int[]>();
            Dictionary<string, List<string>> followersList = new Dictionary<string, List<string>>();

            string command;

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] splitArgs = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command.Contains("joined"))
                {
                    string vloggerName = splitArgs[0];

                    if (!vloggerInfo.ContainsKey(vloggerName) && !followersList.ContainsKey(vloggerName))
                    {
                        vloggerInfo[vloggerName] = new int[2] { 0, 0 };
                        followersList[vloggerName] = new List<string>();
                    }
                }
                if (command.Contains("followed"))
                {
                    string vloggerName1 = splitArgs[0];
                    string vloggerName2 = splitArgs[2];

                    if (vloggerInfo.ContainsKey(vloggerName1) && vloggerInfo.ContainsKey(vloggerName2))
                    {
                        if (vloggerName1 != vloggerName2 && !followersList[vloggerName2].Contains(vloggerName1))
                        {
                            followersList[vloggerName2].Add(vloggerName1);
                            vloggerInfo[vloggerName1][1] += 1;
                            vloggerInfo[vloggerName2][0] += 1;
                        }
                    }
                }
            }

            vloggerInfo = vloggerInfo
                .OrderByDescending(kvp => kvp.Value[0])
                .ThenBy(kvp => kvp.Value[1])
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggerInfo.Count} vloggers in its logs.");
            int num = 1;

            foreach (var kvp in vloggerInfo)
            {
                string vlogger = kvp.Key;
                int followersCount = kvp.Value[0];
                int followingsCount = kvp.Value[1];

                if (num == 1)
                {
                    Console.WriteLine($"{num}. {vlogger} : {followersCount} followers, {followingsCount} following");

                    followersList[vlogger] = followersList[vlogger].OrderBy(l => l).ToList();

                    foreach (var follower in followersList[vlogger])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                else
                {
                    Console.WriteLine($"{num}. {vlogger} : {followersCount} followers, {followingsCount} following");
                }

                num++;
            }
        }
    }
}
