using System;

namespace Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sideSize = double.Parse(Console.ReadLine());
            int paperCount = int.Parse(Console.ReadLine());
            double areaPerPaper = double.Parse(Console.ReadLine());

            double giftArea = sideSize * sideSize * 6;

            double paperArea = 0;

            for (int i = 1; i <= paperCount; i++)
            {
                if (i % 3 != 0)
                {
                    paperArea += areaPerPaper;
                }

                else
                {
                    paperArea += 0.25 * areaPerPaper;
                }
            }

            double percentage = paperArea / giftArea * 100;

            Console.WriteLine($"You can cover {percentage:f2}% of the box.");
        }
    }
}
