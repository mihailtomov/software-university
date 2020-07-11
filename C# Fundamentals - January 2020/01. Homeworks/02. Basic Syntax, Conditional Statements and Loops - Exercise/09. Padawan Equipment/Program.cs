using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double availableMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());

            int freeBelts = studentsCount / 6;

            double lightsabersTotalPrice = Math.Ceiling(1.10 * studentsCount) * lightsabersPrice;
            double beltsTotalPrice = (studentsCount - freeBelts) * beltsPrice;
            double robesTotalPrice = studentsCount * robesPrice;

            double totalCost = lightsabersTotalPrice + beltsTotalPrice + robesTotalPrice;
            double moneyNeeded = totalCost - availableMoney;

            if (availableMoney >= moneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:f2}lv.");
            }

            else
            {
                Console.WriteLine($"Ivan Cho will need {moneyNeeded:f2}lv more.");
            }
        }
    }
}
