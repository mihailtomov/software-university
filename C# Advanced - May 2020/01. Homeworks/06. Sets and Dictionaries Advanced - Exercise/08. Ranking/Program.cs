using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> users = 
                new SortedDictionary<string, Dictionary<string, int>>();

            string contestPasswords;

            while ((contestPasswords = Console.ReadLine()) != "end of contests")
            {
                string[] splitArgs = contestPasswords.Split(":");
                string contest = splitArgs[0];
                string password = splitArgs[1];

                contests[contest] = password;
            }

            string usernamePoints;

            while ((usernamePoints = Console.ReadLine()) != "end of submissions")
            {
                string[] splitArgs = usernamePoints.Split("=>");
                string contest = splitArgs[0];
                string password = splitArgs[1];
                string username = splitArgs[2];
                int points = int.Parse(splitArgs[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();

                        if (!users[username].ContainsKey(contest))
                        {
                            users[username][contest] = points;
                        }
                        else
                        {
                            if (points > users[username][contest])
                            {
                                users[username][contest] = points;
                            }
                        }
                    }
                    else
                    {
                        if (!users[username].ContainsKey(contest))
                        {
                            users[username][contest] = points;
                        }
                        else
                        {
                            if (points > users[username][contest])
                            {
                                users[username][contest] = points;
                            }
                        }
                    }
                }
            }

            string maxUser = "";
            int maxPoints = 0;

            foreach (var user in users)
            {
                string currUser = user.Key;
                Dictionary<string, int> userContests = user.Value;
                int currMaxPoints = 0;

                foreach (var contest in userContests)
                {
                    int currPoints = contest.Value;
                    currMaxPoints += currPoints;                 
                }

                if (currMaxPoints > maxPoints)
                {
                    maxPoints = currMaxPoints;
                    maxUser = currUser;
                }
            }

            int counter = 1;

            foreach (var user in users)
            {
                string currUser = user.Key;
                Dictionary<string, int> userContests = user.Value;

                if (counter == 1)
                {
                    Console.WriteLine($"Best candidate is {maxUser} with total {maxPoints} points.");
                    Console.WriteLine($"Ranking:");
                    counter--;
                }

                Console.WriteLine(currUser);

                userContests = userContests
                    .OrderByDescending(kvp => kvp.Value)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (var contest in userContests)
                {
                    string currContest = contest.Key;
                    int points = contest.Value;

                    Console.WriteLine($"#  {currContest} -> {points}");
                }
            }
        }
    }
}
