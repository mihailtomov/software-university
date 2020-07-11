using System;

namespace _05._Wedding_Presents
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalGuestCount = double.Parse(Console.ReadLine());
            double presentsCount = double.Parse(Console.ReadLine());

            double countA = 0;
            double countB = 0;
            double countV = 0;
            double countG = 0;

            for (int i = 0; i < presentsCount; i++)
            {
                string presentCategory = Console.ReadLine();

                if (presentCategory == "A")
                {
                    countA++;
                }

                if (presentCategory == "B")
                {
                    countB++;
                }

                if (presentCategory == "V")
                {
                    countV++;
                }

                if (presentCategory == "G")
                {
                    countG++;
                }
            }

            double presentAPercent = countA / presentsCount * 100;
            double presentBPercent = countB / presentsCount * 100;
            double presentVPercent = countV / presentsCount * 100;
            double presentGPercent = countG / presentsCount * 100;

            double totalPresentsPercent = 100 * (presentsCount / totalGuestCount);

            Console.WriteLine($"{presentAPercent:f2}%");
            Console.WriteLine($"{presentBPercent:f2}%");
            Console.WriteLine($"{presentVPercent:f2}%");
            Console.WriteLine($"{presentGPercent:f2}%");
            Console.WriteLine($"{totalPresentsPercent:f2}%");
        }
    }
}
