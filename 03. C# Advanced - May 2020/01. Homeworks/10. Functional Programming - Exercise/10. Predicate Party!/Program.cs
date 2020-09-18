using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            string command;

            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] splitArgs = command.Split();

                if (command.Contains("Double"))
                {
                    if (splitArgs[1] == "StartsWith")
                    {
                        string givenString = splitArgs[2];
                        int index = people.FindIndex(x => x.Substring(0, givenString.Length) == givenString);

                        if (index != -1)
                        {
                            var filteredPeople = people
                            .Where(x => x.Substring(0, givenString.Length) == givenString)
                            .ToList();

                            people.InsertRange(index, filteredPeople);
                        }
                    }
                    if (splitArgs[1] == "EndsWith")
                    {
                        string givenString = splitArgs[2];
                        int index = people.FindIndex(x => x.Substring(x.Length - givenString.Length, givenString.Length) == givenString);

                        if (index != -1)
                        {
                            var filteredPeople = people
                            .Where(x => x.Substring(x.Length - givenString.Length, givenString.Length) == givenString)
                            .ToList();

                            people.InsertRange(index, filteredPeople);
                        }
                    }
                    if (splitArgs[1] == "Length")
                    {
                        int length = int.Parse(splitArgs[2]);
                        int index = people.FindIndex(x => x.Length == length);

                        if (index != -1)
                        {
                            var filteredPeople = people
                            .Where(x => x.Length == length)
                            .ToList();

                            people.InsertRange(index, filteredPeople);
                        }
                    }
                }
                if (command.Contains("Remove"))
                {
                    if (splitArgs[1] == "StartsWith")
                    {
                        string givenString = splitArgs[2];

                        people.RemoveAll(x => x.Substring(0, givenString.Length) == givenString);
                    }
                    if (splitArgs[1] == "EndsWith")
                    {
                        string givenString = splitArgs[2];

                        people.RemoveAll(x => x.Substring(x.Length - givenString.Length, givenString.Length) == givenString);
                    }
                    if (splitArgs[1] == "Length")
                    {
                        int length = int.Parse(splitArgs[2]);

                        people.RemoveAll(x => x.Length == length);
                    }
                }
            }

            if (people.Count > 0)
            {
                Console.WriteLine(string.Join(", ", people) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
