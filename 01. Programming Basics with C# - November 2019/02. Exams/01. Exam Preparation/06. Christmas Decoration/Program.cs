using System;

namespace _06._Christmas_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string toyName = Console.ReadLine();
            bool notEnough = false;

            while (toyName != "Stop")
            {
                int toyPrice = 0;

                for (int i = 0; i < toyName.Length; i++)
                {
                    toyPrice += toyName[i];
                }

                if (budget >= toyPrice)
                {
                    Console.WriteLine("Item successfully purchased!");
                    budget -= toyPrice;
                }

                else
                {
                    notEnough = true;
                    break;
                }
                toyName = Console.ReadLine();
            }

            if (notEnough)
            {
                Console.WriteLine("Not enough money!");
            }
            else
            {
                Console.WriteLine($"Money left: {budget}");
            }
        }
    }
}
