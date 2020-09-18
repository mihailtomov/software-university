using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> productsPrice = new Dictionary<string, decimal>();
            Dictionary<string, int> productsQuantity = new Dictionary<string, int>();

            string input;

            while ((input = Console.ReadLine()) != "buy")
            {
                string[] argsInput = input.Split();

                string product = argsInput[0];
                decimal price = decimal.Parse(argsInput[1]);
                int quantity = int.Parse(argsInput[2]);

                if (!productsPrice.ContainsKey(product))
                {
                    productsPrice[product] = 0;
                    productsQuantity[product] = 0;
                }

                productsPrice[product] = price;
                productsQuantity[product] += quantity;
            }

            foreach (var kvp in productsPrice)
            {
                string product = kvp.Key;
                decimal price = kvp.Value;
                int quantity = productsQuantity[product];

                decimal totalPrice = price * quantity;

                Console.WriteLine($"{product} -> {totalPrice:f2}");
            }
        }
    }
}
