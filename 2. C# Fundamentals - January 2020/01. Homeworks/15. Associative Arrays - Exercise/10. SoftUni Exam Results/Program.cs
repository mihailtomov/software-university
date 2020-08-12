using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, List<int>> points = new SortedDictionary<string, List<int>>();
            SortedDictionary<string, int> submissions = new SortedDictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArgs = input
                .Split('-', StringSplitOptions.RemoveEmptyEntries);

                int length = inputArgs.Length;

                if (length == 3)
                {
                    string username = inputArgs[0];
                    string language = inputArgs[1];
                    int score = int.Parse(inputArgs[2]);

                    if (!points.ContainsKey(username))
                    {
                        points[username] = new List<int>();
                    }

                    if (!submissions.ContainsKey(language))
                    {
                        submissions[language] = 0;
                    }

                    points[username].Add(score);
                    submissions[language]++;
                }

                if (length == 2)
                {
                    string username = inputArgs[0];
                    points.Remove(username);
                }
            }

            var filteredPoints = points.OrderByDescending(kvp => kvp.Value.Max()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            var filteredSubmissions = submissions.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            Console.WriteLine("Results:");

            foreach (var kvp in filteredPoints)
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value.Max()}");
            }

            Console.WriteLine("Submissions:");

            foreach (var kvp in filteredSubmissions)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}
