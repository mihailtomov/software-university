using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] argsInput = input
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string courseName = argsInput[0];
                string studentName = argsInput[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }

                courses[courseName].Add(studentName);
            }

            courses = courses
                .OrderByDescending(kvp => kvp.Value.Count)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var kvp in courses)
            {
                string courseName = kvp.Key;
                int registeredStudents = kvp.Value.Count;
                List<string> studentsList = kvp.Value.OrderBy(list => list).ToList();
                
                Console.WriteLine($"{courseName}: {registeredStudents}");

                foreach (var student in studentsList)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
