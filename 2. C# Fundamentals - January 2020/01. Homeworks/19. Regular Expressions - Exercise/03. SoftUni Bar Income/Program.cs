using System;
using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%([A-Z][a-z]+)%[^|$%.]*?<(\w+)>[^|$%.]*?\|(\d+)\|[^|$%.]*?(\d+\.?\d+?)\$";

            Regex regex = new Regex(pattern);

            string input;
            double income = 0;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                bool isValidPattern = regex.IsMatch(input);
                Match match = regex.Match(input);

                double totalPrice = 0;

                if (isValidPattern == true)
                {
                    string customer = match.Groups[1].ToString();
                    string product = match.Groups[2].ToString();
                    int count = int.Parse(match.Groups[3].ToString());
                    double price = double.Parse(match.Groups[4].ToString());

                    totalPrice = count * price;
                    income += totalPrice;

                    Console.WriteLine($"{customer}: {product} - {totalPrice:f2}");
                }
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}
