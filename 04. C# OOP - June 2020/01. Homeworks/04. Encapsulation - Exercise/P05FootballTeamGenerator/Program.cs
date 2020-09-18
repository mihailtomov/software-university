using System;
using System.Collections.Generic;
using System.Linq;

namespace P05FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            List<Team> teams = new List<Team>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitArgs = command.Split(";");

                if (splitArgs[0] == "Team")
                {
                    string teamName = splitArgs[1];

                    try
                    {
                        teams.Add(new Team(teamName));
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                if (splitArgs[0] == "Add")
                {
                    string teamName = splitArgs[1];
                    string playerName = splitArgs[2];
                    int endurance = int.Parse(splitArgs[3]);
                    int sprint = int.Parse(splitArgs[4]);
                    int dribble = int.Parse(splitArgs[5]);
                    int passing = int.Parse(splitArgs[6]);
                    int shooting = int.Parse(splitArgs[7]);

                    Team team = teams.FirstOrDefault(x => x.Name == teamName);

                    if (team != null)
                    {
                        try
                        {
                            team.AddPlayer(new Player(playerName, endurance, sprint, dribble, passing, shooting));
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                if (splitArgs[0] == "Remove")
                {
                    string teamName = splitArgs[1];
                    string playerName = splitArgs[2];

                    Team team = teams.FirstOrDefault(x => x.Name == teamName);

                    if (team != null)
                    {
                        team.RemovePlayer(playerName);
                    }
                }
                if (splitArgs[0] == "Rating")
                {
                    string teamName = splitArgs[1];

                    Team team = teams.FirstOrDefault(x => x.Name == teamName);

                    if (team != null)
                    {
                        Console.WriteLine($"{teamName} - {team.Rating}");
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
            }
        }
    }
}
