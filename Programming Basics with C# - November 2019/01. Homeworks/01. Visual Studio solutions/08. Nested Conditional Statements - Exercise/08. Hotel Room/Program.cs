using System;

namespace _08._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double nights = double.Parse(Console.ReadLine());

            double studioCost = 0;
            double apartmentCost = 0;
            double discount = 0;

            if (month == "May" || month == "October")
            {
                studioCost = nights * 50;
                apartmentCost = nights * 65;
                if (nights > 7 && nights <= 14)
                {
                    discount = 0.05;
                    studioCost = studioCost - (studioCost * discount);
                }

                if (nights > 14)
                {
                    discount = 0.30;
                    studioCost = studioCost - (studioCost * discount);
                }
            }

            if (month == "June" || month == "September")
            {
                studioCost = nights * 75.20;
                apartmentCost = nights * 68.70;
                if (nights > 14)
                {
                    discount = 0.20;
                    studioCost = studioCost - (studioCost * discount);
                }
            }

            if (month == "July" || month == "August")
            {
                studioCost = nights * 76;
                apartmentCost = nights * 77;
            }

            if (nights > 14)
            {
                apartmentCost = apartmentCost - (apartmentCost * 0.10);
            }

            Console.WriteLine($"Apartment: {apartmentCost:F2} lv.");
            Console.WriteLine($"Studio: {studioCost:F2} lv.");
        }
    }
}
