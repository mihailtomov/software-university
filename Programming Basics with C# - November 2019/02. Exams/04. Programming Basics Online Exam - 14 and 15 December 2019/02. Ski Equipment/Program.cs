using System;

namespace _02._Ski_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalBudget = double.Parse(Console.ReadLine());
            double skiPrice = double.Parse(Console.ReadLine());
            double skiPolePrice = double.Parse(Console.ReadLine());

            double skiShoes = 0.40 * skiPrice;
            double skiEquipment = 1.40 * skiPrice;

            double totalPrice = skiPrice + skiPolePrice + skiShoes + skiEquipment;
            double totalPriceWithoutSkiPole = skiPrice + skiShoes + skiEquipment;

            if (totalPriceWithoutSkiPole > 800)
            {
                totalPrice -= skiPolePrice;
            }

            double leftOver = totalBudget - totalPrice;
            double notEnough = totalPrice - totalBudget;

            if (totalBudget >= totalPrice)
            {
                Console.WriteLine($"Angel's sum is {totalPrice:f2} lv. He has {leftOver:f2} lv. left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! You need {notEnough:f2} leva more!");
            }
        }
    }
}
