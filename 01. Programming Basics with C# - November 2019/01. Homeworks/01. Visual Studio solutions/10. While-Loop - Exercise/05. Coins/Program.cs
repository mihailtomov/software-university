using System;

namespace _05._Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double change = double.Parse(Console.ReadLine());
            double coinValue = 0.0;
            double coinCount = 0.0;
            double remainder = 0.0;

            while (change > coinValue)
            {
                if (change % 2 != 0)
                {
                    coinCount++;
                    remainder += change;
                }
            }
        }
    }
}
