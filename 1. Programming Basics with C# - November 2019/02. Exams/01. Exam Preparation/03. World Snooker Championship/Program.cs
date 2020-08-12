using System;

namespace _03._World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            string championshipStage = Console.ReadLine();
            string ticketType = Console.ReadLine();
            double ticketsCount = double.Parse(Console.ReadLine());
            string pictureWithTrophy = Console.ReadLine();

            double standardPrice = 0.0;
            double premiumPrice = 0.0;
            double vipPrice = 0.0;

            if (championshipStage == "Quarter final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        standardPrice = ticketsCount * 55.50;
                        break;
                    case "Premium":
                        premiumPrice = ticketsCount * 105.20;
                        break;
                    case "VIP":
                        vipPrice = ticketsCount * 118.90;
                        break;
                }
            }

            if (championshipStage == "Semi final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        standardPrice = ticketsCount * 75.88;
                        break;
                    case "Premium":
                        premiumPrice = ticketsCount * 125.22;
                        break;
                    case "VIP":
                        vipPrice = ticketsCount * 300.40;
                        break;
                }
            }

            if (championshipStage == "Final")
            {
                switch (ticketType)
                {
                    case "Standard":
                        standardPrice = ticketsCount * 110.10;
                        break;
                    case "Premium":
                        premiumPrice = ticketsCount * 160.66;
                        break;
                    case "VIP":
                        vipPrice = ticketsCount * 400;
                        break;
                }
            }

            double totalPrice = standardPrice + premiumPrice + vipPrice;
            double trophyPrice = 40 * ticketsCount;

            if (pictureWithTrophy == "Y")
            {
                if (totalPrice > 4000)
                {
                    totalPrice = totalPrice * 0.75;
                }

                else if (totalPrice > 2500)
                {
                    totalPrice = (totalPrice * 0.90) + trophyPrice;
                }

                else 
                {
                    totalPrice += trophyPrice;
                }
            }

            else if (pictureWithTrophy == "N")
            {
                if (totalPrice > 4000)
                {
                    totalPrice = totalPrice * 0.75;
                }

                else if (totalPrice > 2500)
                {
                    totalPrice = totalPrice * 0.90;
                }
            }
           

            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
