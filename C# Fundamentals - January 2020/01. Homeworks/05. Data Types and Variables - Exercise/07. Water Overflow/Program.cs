using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int tankCapacity = 0;

            for (int i = 0; i < n; i++)
            {
                int litersOfWater = int.Parse(Console.ReadLine());
                tankCapacity += litersOfWater;

                if (tankCapacity > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    tankCapacity -= litersOfWater;
                }
            }

            Console.WriteLine(tankCapacity);
        }
    }
}
