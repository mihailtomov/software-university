using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            Predicate<string> filterNames = name => name.Length <= length;

            Action<List<string>, Predicate<string>> printFilteredNames = (list, predicate) =>
            {
                foreach (var name in list)
                {
                    if (predicate(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            printFilteredNames(names, filterNames);
        }
    }
}
