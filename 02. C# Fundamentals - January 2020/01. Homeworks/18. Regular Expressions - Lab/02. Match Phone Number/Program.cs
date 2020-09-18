using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Match_Phone_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\+359(\ |\-)2\1[\d]{3}\1[\d]{4}\b";

            string numbers = Console.ReadLine();

            MatchCollection matches = Regex.Matches(numbers, regex);

            string[] matchingNumbers = matches.Cast<Match>().Select(v => v.Value.Trim()).ToArray();

            Console.WriteLine(String.Join(", ", matchingNumbers));
        }
    }
}
