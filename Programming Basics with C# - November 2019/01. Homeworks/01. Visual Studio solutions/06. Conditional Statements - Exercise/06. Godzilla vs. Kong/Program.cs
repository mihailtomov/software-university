using System;

namespace _06._Godzilla_vs._Kong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double clothingPricePerExtra = double.Parse(Console.ReadLine());

            double sceneryPrice = 0.1 * budget;

            double totalClothingPrice = extras * clothingPricePerExtra;

            double totalClothingPriceDiscount = 0.1 * totalClothingPrice;

            double totalPrice = sceneryPrice + totalClothingPrice;
          

            if (totalPrice > budget && extras > 150)
            {
                double notEnough = (totalPrice - totalClothingPriceDiscount) - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {notEnough:F2} leva more.");
            }

            else if (totalPrice <= budget && extras > 150)
            {
                double leftOver = budget - (totalPrice - totalClothingPriceDiscount);
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftOver:F2} leva left.");
            }

            else if (totalPrice > budget && extras <= 150)
            {
                double notEnough = totalPrice - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {notEnough:F2} leva more.");

            }

            else if (totalPrice <= budget && extras <= 150)
            {
                double leftOver = budget - totalPrice;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {leftOver:F2} leva left.");
            }
        }
    }
}
