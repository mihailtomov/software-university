using System;

namespace _03._Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string sushiType = Console.ReadLine();
            string restaurantName = Console.ReadLine();
            int servingsCount = int.Parse(Console.ReadLine());
            string delivery = Console.ReadLine();

            double sashimiPrice = 0;
            double makiPrice = 0;
            double uramakiPrice = 0;
            double temakiPrice = 0;

            if (restaurantName == "Sushi Zone")
            {
                if (sushiType == "sashimi")
                {
                    sashimiPrice = 4.99;
                }

                if (sushiType == "maki")
                {
                    makiPrice = 5.29;
                }

                if (sushiType == "uramaki")
                {
                    uramakiPrice = 5.99;
                }

                if (sushiType == "temaki")
                {
                    temakiPrice = 4.29;
                }
            }

            if (restaurantName == "Sushi Time")
            {
                if (sushiType == "sashimi")
                {
                    sashimiPrice = 5.49;
                }

                if (sushiType == "maki")
                {
                    makiPrice = 4.69;
                }

                if (sushiType == "uramaki")
                {
                    uramakiPrice = 4.49;
                }

                if (sushiType == "temaki")
                {
                    temakiPrice = 5.19;
                }
            }

            if (restaurantName == "Sushi Bar")
            {
                if (sushiType == "sashimi")
                {
                    sashimiPrice = 5.25;
                }

                if (sushiType == "maki")
                {
                    makiPrice = 5.55;
                }

                if (sushiType == "uramaki")
                {
                    uramakiPrice = 6.25;
                }

                if (sushiType == "temaki")
                {
                    temakiPrice = 4.75;
                }
            }

            if (restaurantName == "Asian Pub")
            {
                if (sushiType == "sashimi")
                {
                    sashimiPrice = 4.50;
                }

                if (sushiType == "maki")
                {
                    makiPrice = 4.80;
                }

                if (sushiType == "uramaki")
                {
                    uramakiPrice = 5.50;
                }

                if (sushiType == "temaki")
                {
                    temakiPrice = 5.50;
                }
            }

            double totalCost = servingsCount * (sashimiPrice + makiPrice + uramakiPrice + temakiPrice);

            if (delivery == "Y")
            {
                totalCost *= 1.2;
            }

            if (restaurantName == "Sushi Zone" || restaurantName == "Sushi Time" || restaurantName == "Sushi Bar" || restaurantName == "Asian Pub")
            {
                Console.WriteLine($"Total price: {Math.Ceiling(totalCost)} lv.");
            }

            else
            {
                Console.WriteLine($"{restaurantName} is invalid restaurant!");
            }
        }
    }
}
