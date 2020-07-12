using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string currName = data[0];
                decimal currGrade = decimal.Parse(data[1]);

                if (!students.ContainsKey(currName))
                {
                    students[currName] = new List<decimal>() {currGrade};
                }
                else
                {
                    students[currName].Add(currGrade);
                }
            }

            foreach (var kvp in students)
            {
                string currStudent = kvp.Key;
                List<decimal> grades = kvp.Value;

                Console.WriteLine($"{currStudent} -> {string.Join(" ", grades.Select(x => x.ToString("f2")))} (avg: {grades.Average():f2})");
            }
        }
    }
}
