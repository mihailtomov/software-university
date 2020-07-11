using System;

namespace _01._Christmas_Sweets
{
    class Program
    {
        static void Main(string[] args)
        {
            double balklavaPricePerKg = double.Parse(Console.ReadLine());
            double muffinsPricePerKg = double.Parse(Console.ReadLine());
            double stollenKilograms = double.Parse(Console.ReadLine());
            double candyKilograms = double.Parse(Console.ReadLine());
            int biscuitsKilograms = int.Parse(Console.ReadLine());

            double biscuitsPrice = biscuitsKilograms * 7.50;
            double candyPrice = candyKilograms * (1.8 * muffinsPricePerKg);
            double stollenPrice = stollenKilograms * (1.6 * balklavaPricePerKg);

            double totalPrice = biscuitsPrice + candyPrice + stollenPrice;

            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}