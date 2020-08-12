using System;

namespace _04._Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int performerCost = int.Parse(Console.ReadLine());
            string groupCount = Console.ReadLine();

            int costPerPerson = 0;
            int totalProfit = 0;
            int totalGuestsCount = 0;

            while (groupCount != "The restaurant is full")
            {
                int currentCount = int.Parse(groupCount);
                totalGuestsCount += currentCount;

                if (currentCount < 5)
                {
                    costPerPerson = 100;
                }

                else
                {
                    costPerPerson = 70;
                }

                totalProfit += currentCount * costPerPerson;

                groupCount = Console.ReadLine();
            }

            int leftOver = totalProfit - performerCost;

            if (totalProfit >= performerCost)
            {
                Console.WriteLine($"You have {totalGuestsCount} guests and {leftOver} leva left."); 
            }

            else
            {
                Console.WriteLine($"You have {totalGuestsCount} guests and {totalProfit} leva income, but no singer.");
            }
        }
    }
}
