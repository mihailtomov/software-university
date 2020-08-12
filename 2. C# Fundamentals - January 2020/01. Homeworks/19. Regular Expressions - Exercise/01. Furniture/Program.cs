using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string pattern = @">>([A-Z][a-z]+|[A-Z]+)<<(\d+\.\d+|\d+)!(\d+)";
            Regex regex = new Regex(pattern);
            List<string> boughtFurniture = new List<string>();
            double totalPrice = 0;

            while ((input = Console.ReadLine()) != "Purchase")
            {
                bool isValidInput = regex.IsMatch(input);

                if (isValidInput == true)
                {
                    Match match = regex.Match(input);
                    string furnitureName = match.Groups[1].ToString();
                    double price = double.Parse(match.Groups[2].ToString());
                    int quantity = int.Parse(match.Groups[3].ToString());

                    boughtFurniture.Add(furnitureName);
                    totalPrice += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");

            foreach (string furniture in boughtFurniture)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
