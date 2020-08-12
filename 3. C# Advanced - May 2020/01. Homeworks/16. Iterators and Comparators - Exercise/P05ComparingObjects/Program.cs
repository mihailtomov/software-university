using System;
using System.Collections.Generic;

namespace P05ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] splitArgs = input.Split();
                string name = splitArgs[0];
                int age = int.Parse(splitArgs[1]);
                string town = splitArgs[2];

                people.Add(new Person(name, age, town));
            }

            int n = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[n];
            int matchesCount = 0;
            int unquealPeopleCount = 0;
            int totalPeopleCount = people.Count;

            for (int i = 0; i < people.Count; i++)
            {
                Person person = people[i];

                if (person.CompareTo(personToCompare) == 0)
                {
                    matchesCount++;
                }
                else
                {
                    unquealPeopleCount++;
                }
            }

            if (matchesCount > 1)
            {
                Console.WriteLine($"{matchesCount} {unquealPeopleCount} {totalPeopleCount}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
