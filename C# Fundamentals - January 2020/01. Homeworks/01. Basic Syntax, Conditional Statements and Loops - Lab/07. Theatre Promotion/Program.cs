using System;

namespace _07._Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfDay = Console.ReadLine();
            int ageOfPerson = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if (ageOfPerson >= 0 && ageOfPerson <= 18)
            {
                if (typeOfDay == "Weekday")
                {
                    ticketPrice += 12;
                }

                if (typeOfDay == "Weekend")
                {
                    ticketPrice += 15;
                }

                if (typeOfDay == "Holiday")
                {
                    ticketPrice += 5;
                }

                Console.WriteLine($"{ticketPrice}$");
            }

            else if (ageOfPerson > 18 && ageOfPerson <= 64)
            {
                if (typeOfDay == "Weekday")
                {
                    ticketPrice += 18;
                }

                if (typeOfDay == "Weekend")
                {
                    ticketPrice += 20;
                }

                if (typeOfDay == "Holiday")
                {
                    ticketPrice += 12;
                }
                Console.WriteLine($"{ticketPrice}$");
            }

            else if (ageOfPerson > 64 && ageOfPerson <= 122)
            {
                if (typeOfDay == "Weekday")
                {
                    ticketPrice += 12;
                }

                if (typeOfDay == "Weekend")
                {
                    ticketPrice += 15;
                }

                if (typeOfDay == "Holiday")
                {
                    ticketPrice += 10;
                }
                Console.WriteLine($"{ticketPrice}$");
            }

            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
