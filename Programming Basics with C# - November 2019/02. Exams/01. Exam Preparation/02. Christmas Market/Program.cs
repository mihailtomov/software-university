using System;

namespace _02._Christmas_Market
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            int fantasyBooksCount = int.Parse(Console.ReadLine());
            int horrorBooksCount = int.Parse(Console.ReadLine());
            int romanticBooksCount = int.Parse(Console.ReadLine());

            double fantasyCost = fantasyBooksCount * 14.90;
            double horrorCost = horrorBooksCount * 9.80;
            double romanticCost = romanticBooksCount * 4.30;

            double totalProfit = fantasyCost + horrorCost + romanticCost;

            totalProfit *= 0.8;

            if (totalProfit >= moneyNeeded)
            {
                double profit = totalProfit - moneyNeeded;
                double pay = Math.Floor(profit * 0.1);

                totalProfit = totalProfit - pay;

                Console.WriteLine($"{totalProfit:f2} leva donated.");
                Console.WriteLine($"Sellers will receive {pay} leva.");
            }

            else
            {
                double diff = moneyNeeded - totalProfit;
                Console.WriteLine($"{diff:f2} money needed.");
            }
        }
    }
}
