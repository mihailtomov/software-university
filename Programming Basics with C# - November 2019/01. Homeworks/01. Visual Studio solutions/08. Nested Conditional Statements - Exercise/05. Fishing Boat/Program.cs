using System;

namespace _05._Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double fishersCount = double.Parse(Console.ReadLine());

            double price = 0;
            double discount = 0;

            if (season == "Spring")
            {
                price = 3000;

                if (fishersCount <= 6)
                {
                    discount = 0.1;
                    price = price - (price * discount);
                }

                if (fishersCount > 7 && fishersCount <= 11)
                {
                    discount = 0.15;
                    price = price - (price * discount);
                }

                if (fishersCount >= 12)
                {
                    discount = 0.25;
                    price = price - (price * discount);
                }

            }

            if (season == "Summer" || season == "Autumn")
            {
                price = 4200;

                if (fishersCount <= 6)
                {
                    discount = 0.1;
                    price = price - (price * discount);
                }

                if (fishersCount > 7 && fishersCount <= 11)
                {
                    discount = 0.15;
                    price = price - (price * discount);
                }

                if (fishersCount >= 12)
                {
                    discount = 0.25;
                    price = price - (price * discount);
                }
            }

            if (season == "Winter")
            {
                price = 2600;

                
                    if (fishersCount <= 6)
                {
                    discount = 0.1;
                    price = price - (price * discount);
                }

                if (fishersCount > 7 && fishersCount <= 11)
                {
                    discount = 0.15;
                    price = price - (price * discount);
                }

                if (fishersCount >= 12)
                {
                    discount = 0.25;
                    price = price - (price * discount);
                }
            }

            if (season != "Autumn")
            {
                if (fishersCount % 2 == 0)
                {
                    discount = 0.05;
                    price = price - (price * discount);
                }
            }

            double leftOver = budget - price;
            double notEnough = price - budget;

            if (budget >= price)
            {
                Console.WriteLine($"Yes! You have {leftOver:F2} leva left.");
            }

            else
            {
                Console.WriteLine($"Not enough money! You need {notEnough:F2} leva.");
            }
        }
    }
}
