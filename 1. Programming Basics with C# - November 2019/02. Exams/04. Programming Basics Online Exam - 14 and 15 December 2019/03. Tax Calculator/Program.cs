using System;

namespace _03._Tax_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int enginePower = int.Parse(Console.ReadLine());
            string cityName = Console.ReadLine();
            string ecoStandard = Console.ReadLine();

            double price = 0;

            if (cityName == "Sofia")
            {
                if (enginePower <= 37)
                {
                    price = enginePower * 1.43;
                }

                else if (enginePower > 37 && enginePower <= 55)
                {
                    price = enginePower * 1.50;
                }

                else
                {
                    price = enginePower * 2.68;
                }
            }

            if (cityName == "Vidin")
            {
                if (enginePower <= 37)
                {
                    price = enginePower * 1.34;
                }

                else if (enginePower > 37 && enginePower <= 55)
                {
                    price = enginePower * 1.40;
                }

                else
                {
                    price = enginePower * 2.54;
                }
            }

            if (cityName == "Varna")
            {
                if (enginePower <= 37)
                {
                    price = enginePower * 1.37;
                }

                else if (enginePower > 37 && enginePower <= 55)
                {
                    price = enginePower * 1.40;
                }

                else
                {
                    price = enginePower * 2.57;
                }
            }

            if (ecoStandard == "Euro 4")
            {
                price = 0.85 * price;
            }

            if (ecoStandard == "Euro 5")
            {
                price = 0.83 * price;
            }

            if (ecoStandard == "Euro 6")
            {
                price = 0.80 * price;
            }

            Console.WriteLine($"{price:f2} lv");
        }
    }
}
