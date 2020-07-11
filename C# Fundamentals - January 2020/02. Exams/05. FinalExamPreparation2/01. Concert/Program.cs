using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTime = new Dictionary<string, int>();

            string command;
            int totalTime = 0;

            while ((command = Console.ReadLine()) != "start of concert")
            {
                string[] splitArgs = command.Split("; ");
                
                if (command.Contains("Add"))
                {
                    string bandName = splitArgs[1];
                    string members = splitArgs[2];
                    string[] memberList = members.Split(", ");

                    if (!bandMembers.ContainsKey(bandName))
                    {
                        bandMembers[bandName] = new List<string>();

                        for (int i = 0; i < memberList.Length; i++)
                        {
                            if (!bandMembers[bandName].Contains(memberList[i]))
                            {
                                bandMembers[bandName].Add(memberList[i]);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < memberList.Length; i++)
                        {
                            if (!bandMembers[bandName].Contains(memberList[i]))
                            {
                                bandMembers[bandName].Add(memberList[i]);
                            }
                        }
                    }
                }

                if (command.Contains("Play"))
                {
                    string bandName = splitArgs[1];
                    int time = int.Parse(splitArgs[2]);
                    totalTime += time;

                    if (!bandTime.ContainsKey(bandName))
                    {
                        bandTime[bandName] = time;
                    }
                    else
                    {
                        bandTime[bandName] += time;
                    }
                }
            }

            bandTime = bandTime
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            string bandToPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var band in bandTime)
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            foreach (var band in bandMembers)
            {
                if (band.Key == bandToPrint)
                {
                    Console.WriteLine(band.Key);

                    foreach (var member in band.Value)
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }       
            }
        }
    }
}
