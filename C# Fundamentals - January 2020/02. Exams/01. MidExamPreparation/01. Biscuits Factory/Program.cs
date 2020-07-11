using System;

namespace _01._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int otherFactory = int.Parse(Console.ReadLine());

            int totalProduction = 0;

            for (int i = 1; i <= 30; i++)
            { 
                if (i % 3 == 0)
                {
                    totalProduction += (int)(0.75 * biscuitsPerWorker * workers);
                    continue;
                }

                totalProduction += biscuitsPerWorker * workers;
            }

            double diff = Math.Abs(totalProduction - otherFactory);
            double percentage = (diff / otherFactory) * 100;

            Console.WriteLine($"You have produced {totalProduction} biscuits for the past month.");

            if (totalProduction > otherFactory)
            {
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }

            else
            {
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}
