using System;

namespace _01._Rent
{
    class Program
    {
        static void Main(string[] args)
        {
            int monthsCount = int.Parse(Console.ReadLine());
            int commisionPercent = int.Parse(Console.ReadLine());
            double rentPricePerMonth = double.Parse(Console.ReadLine());

            double firstHalf = monthsCount / 2;
            double secondHalf = monthsCount / 2 + monthsCount % 2;

            double firstHalfPrice = firstHalf * rentPricePerMonth;
            double secondHalfPrice = secondHalf * (rentPricePerMonth * 0.80);

            double totalForPeriod = firstHalfPrice + secondHalfPrice;

            double brokerPercent = commisionPercent * totalForPeriod / 100;

            double totalRentPrice = totalForPeriod + brokerPercent;

            Console.WriteLine($"Total: {totalRentPrice:f2}");
        }
    }
}
