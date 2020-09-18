using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int daysCount = 0;
            int spiceStorage = 0;

            if (startingYield < 100)
            {
                Console.WriteLine(daysCount);
                Console.WriteLine(spiceStorage);
                return;
            }

            while (startingYield >= 100)
            {
                spiceStorage += startingYield - 26;
                startingYield -= 10;
                daysCount++;
            }

            spiceStorage -= 26;

            Console.WriteLine(daysCount);
            Console.WriteLine(spiceStorage);
        }
    }
}
