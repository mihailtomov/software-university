using System;

namespace _04._New_House
{
    class Program
    {
        static void Main(string[] args)
        {
            string flowerType = Console.ReadLine();
            double flowerCount = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double price = 0;
            double discount = 0;

            if (flowerType == "Roses")
            {
                price = flowerCount * 5;
                if (flowerCount > 80)          
                    discount = 0.1;
                    price = price - (price * discount);
            }

            else if (flowerType == "Dahlias")
            {
                price = flowerCount * 3.80;
                if (flowerCount > 90)
                    discount = 0.15;
                    price = price - (price * discount);
            }

            else if (flowerType == "Tulips")
            {
                price = flowerCount * 2.80;
                if (flowerCount > 80)
                    discount = 0.15;
                    price = price - (price * discount);
            }

            else if (flowerType == "Narcissus")
            {
                price = flowerCount * 3;
                if (flowerCount < 120)
                    discount = 0.15;
                    price = price + (price * discount);
            }

            else if (flowerType == "Gladiolus")
            {
                price = flowerCount * 2.50;
                if (flowerCount < 80)
                    discount = 0.20;
                    price = price + (price * discount);
            }

            double leftOver = budget - price;
            double notEnough = price - budget;

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowerType} and {leftOver:F2} leva left.");
            }

            else
            {
                Console.WriteLine($"Not enough money, you need {notEnough:F2} leva more.");
            }
        }
    }
}
