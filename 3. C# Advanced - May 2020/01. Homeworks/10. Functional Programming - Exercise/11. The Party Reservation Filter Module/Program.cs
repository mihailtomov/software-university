using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string command;

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            while((command = Console.ReadLine()) != "Print")
            {
                string[] splitArgs = command.Split(";");

                if (command.Contains("Add"))
                {
                    string type = splitArgs[1];
                    string parameter = splitArgs[2];
                    filters.Add(type + parameter, FilterByCommand(type, parameter));
                }
                if (command.Contains("Remove"))
                {
                    string type = splitArgs[1];
                    string parameter = splitArgs[2];
                    filters.Remove(type + parameter);                
                }
            }

            foreach (var kvp in filters)
            {
                Predicate<string> filter = kvp.Value;

                names.RemoveAll(filter);
            }

            Console.WriteLine(string.Join(" ", names));
        }

        static Predicate<string> FilterByCommand(string type, string parameter)
        {
            switch (type)
            {
                case "Starts with":
                    return x => x.StartsWith(parameter);
                case "Ends with":
                    return x => x.EndsWith(parameter);
                case "Length":
                    return x => x.Length == int.Parse(parameter);
                default:
                    return x => x.Contains(parameter);
            }
        }
    }
}
