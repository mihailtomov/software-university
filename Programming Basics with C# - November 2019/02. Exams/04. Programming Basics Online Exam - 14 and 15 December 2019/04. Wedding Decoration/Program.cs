using System;

namespace _04._Wedding_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalBudget = double.Parse(Console.ReadLine());

            bool isStop = false;
            double balloonsCount = 0;
            double flowersCount = 0;
            double candlesCount = 0;
            double ribbonMeters = 0;
            double currentMoneySpent = 0;
            double totalSpent = 0;

            while (totalBudget > 0)
            {
                string productType = Console.ReadLine();

                if (productType == "stop")
                {
                    isStop = true;
                    break;
                }

                double productCount = double.Parse(Console.ReadLine());

                if (productType == "balloons")
                {
                    currentMoneySpent = 0.1 * productCount;
                    balloonsCount += productCount;
                }

                else if (productType == "flowers")
                {
                    currentMoneySpent = 1.5 * productCount;
                    flowersCount += productCount;
                }

                else if (productType == "candles")
                {
                    currentMoneySpent = 0.5 * productCount;
                    candlesCount += productCount;
                }

                else if (productType == "ribbon")
                {
                    currentMoneySpent = 2 * productCount;
                    ribbonMeters += productCount;
                }

                totalSpent += currentMoneySpent;
                totalBudget -= currentMoneySpent;
            }

            if (isStop)
            {
                Console.WriteLine($"Spend money: {totalSpent:f2}");
                Console.WriteLine($"Money left: {totalBudget:f2}");
            }

            if (totalBudget <= 0)
            {
                Console.WriteLine("All money is spent!");
            }

            Console.WriteLine($"Purchased decoration is {balloonsCount} balloons, {ribbonMeters} m ribbon, {flowersCount} flowers and {candlesCount} candles.");
        }
    }
}
