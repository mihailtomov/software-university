using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double collectedMoney = 0;

            for (int i = 1; i <= months; i++)
            {
                if (i % 2 != 0 && i != 1)
                {
                    collectedMoney -= 0.16 * collectedMoney;
                }

                if (i % 4 == 0)
                {
                    collectedMoney += 0.25 * collectedMoney;
                }

                collectedMoney += 0.25 * journeyCost;
            }

            double diff = 0;

            if (collectedMoney >= journeyCost)
            {
                diff = collectedMoney - journeyCost;
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {diff:f2}lv. for souvenirs.");
            }

            else
            {
                diff = journeyCost - collectedMoney;
                Console.WriteLine($"Sorry. You need {diff:f2}lv. more.");
            }
        }
    }
}
