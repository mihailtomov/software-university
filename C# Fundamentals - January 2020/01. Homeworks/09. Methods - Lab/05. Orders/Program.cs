using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            PrintPriceOfOrder(product, quantity);
        }

        static void PrintPriceOfOrder(string input, int num)
        {
            switch (input)
            {
                case "coffee":
                    Console.WriteLine($"{1.50 * num:f2}");
                    break;
                case "water":
                    Console.WriteLine($"{1.00 * num:f2}");
                    break;
                case "coke":
                    Console.WriteLine($"{1.40 * num:f2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{2.00 * num:f2}");
                    break;
            }
        }
    }
}
