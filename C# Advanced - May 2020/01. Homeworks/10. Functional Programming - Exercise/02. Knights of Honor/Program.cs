using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printName = name => Console.WriteLine(name);

            Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(name => "Sir " + name)
                .ToList()
                .ForEach(printName);
        }
    }
}
