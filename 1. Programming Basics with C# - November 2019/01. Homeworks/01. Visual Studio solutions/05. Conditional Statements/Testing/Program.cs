using System;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            double tripCost = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollCount = int.Parse(Console.ReadLine());
            int bearCount = int.Parse(Console.ReadLine());
            int minionCount = int.Parse(Console.ReadLine());
            int truckCount = int.Parse(Console.ReadLine());

            int toyCount = puzzleCount + dollCount + bearCount + minionCount + truckCount;

            double puzzleTotalPrice = puzzleCount * 2.60;
            double dollTotalPrice = dollCount * 3;
            double bearTotalPrice = bearCount * 4.10;
            double minionTotalPrice = minionCount * 8.20;
            double truckTotalPrice = truckCount * 2;

            double totalPrice = puzzleTotalPrice + dollTotalPrice + bearTotalPrice + minionTotalPrice + truckTotalPrice;

            if (toyCount >= 50)
            {
                totalPrice = totalPrice * 0.75;

                //totalPrice *= 0.75;
            }

            double taxPayment = totalPrice * 0.1;
            totalPrice = totalPrice - taxPayment;

            if (totalPrice >= tripCost)
            {
                double difference = totalPrice - tripCost;
                Console.WriteLine($"Yes! {difference:F2} lv left.");
            }
            else
            {
                double difference = tripCost - totalPrice;
                Console.WriteLine($"Not enough money! {difference:F2} lv needed.");
            }

        }
    }
}
