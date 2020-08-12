using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string companyName = inputArgs[0];
                string employeeId = inputArgs[1];

                if (!companies.ContainsKey(companyName))
                {
                    companies[companyName] = new List<string>();
                }

                if (!companies[companyName].Contains(employeeId))
                {
                    companies[companyName].Add(employeeId);
                }
            }

            var orderedCompanies = companies
                .OrderBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var kvp in orderedCompanies)
            {
                string companyName = kvp.Key;
                List<string> employees = kvp.Value;

                Console.WriteLine(companyName);

                foreach (var id in employees)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
