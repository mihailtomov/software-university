using System;

namespace _06._Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "input";
            string vacationType = "input";
            double expenses = 0;
            

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    destination = "Bulgaria";
                    vacationType = "Camp";
                    expenses = 0.3 * budget;
                }

                if (season == "winter")
                {
                    destination = "Bulgaria";
                    vacationType = "Hotel";
                    expenses = 0.7 * budget;
                }
                
            }

            if (budget > 100 && budget <= 1000)
            {  
                if (season == "summer")
                {
                    destination = "Balkans";
                    vacationType = "Camp";
                    expenses = 0.4 * budget;
                }

                if (season == "winter")
                {
                    destination = "Balkans";
                    vacationType = "Hotel";
                    expenses = 0.8 * budget;
                }
            }

            if (budget > 1000)
                {
                    destination = "Europe";
                    vacationType = "Hotel";
                    expenses = 0.9 * budget;
                }           
            
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{vacationType} - {expenses:F2}");
        }
    }
}
