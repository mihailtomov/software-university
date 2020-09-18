using System;

namespace _04._Small_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0.0;


            if (city == "Sofia")
            {
                if (product == "coffee")
                price = quantity * 0.50;
                
                if (product == "water")
                price = quantity * 0.80;
                
                if (product == "beer")
                    price = quantity * 1.20;
                
                if (product == "sweets")
                    price = quantity * 1.45;
               
                if (product == "peanuts")
                    price = quantity * 1.60;

                Console.WriteLine(price);
            }

            if (city == "Plovdiv")
            {
                if (product == "coffee")
                    price = quantity * 0.40;
               
                if (product == "water")
                    price = quantity * 0.70;
                
                if (product == "beer")
                    price = quantity * 1.15;
                
                if (product == "sweets")
                    price = quantity * 1.30;
                
                if (product == "peanuts")
                    price = quantity * 1.50;

                Console.WriteLine(price);
            }

            if (city == "Varna")
            {
                if (product == "coffee")
                    price = quantity * 0.45;
                
                if (product == "water")
                    price = quantity * 0.70;
                
                if (product == "beer")
                    price = quantity * 1.10;
                
                if (product == "sweets")
                    price = quantity * 1.35;
                
                if (product == "peanuts")
                    price = quantity * 1.55;

                Console.WriteLine(price);
            }
        }
    }
}
