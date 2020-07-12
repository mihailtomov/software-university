using System;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            string input;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] splitArgs = input.Split(", ");
                string shop = splitArgs[0];
                string product = splitArgs[1];
                double price = double.Parse(splitArgs[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                    shops[shop][product] = price;
                }
                else
                {
                    shops[shop][product] = price;
                }
            }

            foreach (var shop in shops)
            {
                string currShop = shop.Key;
                Dictionary<string, double> products = shop.Value;

                Console.WriteLine($"{currShop}->");

                foreach (var product in products)
                {
                    string currProduct = product.Key;
                    double currPrice = product.Value;

                    Console.WriteLine($"Product: {currProduct}, Price: {currPrice}");
                }
            }
        }
    }
}
