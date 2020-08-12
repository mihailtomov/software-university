using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Func<string, bool> ifUpperCaseWord = x => x[0] == x.ToUpper()[0];

            string[] filteredText = text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(ifUpperCaseWord)
                .ToArray();

            foreach (var word in filteredText)
            {
                Console.WriteLine(word);
            }
        }
    }
}
