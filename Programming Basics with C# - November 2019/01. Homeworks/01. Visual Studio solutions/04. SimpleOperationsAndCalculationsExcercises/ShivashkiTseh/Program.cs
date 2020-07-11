using System;

namespace ShivashkiTseh
{
    class Program
    {
        static void Main(string[] args)
        {
            int tables = int.Parse(Console.ReadLine());
            double tableLength = double.Parse(Console.ReadLine());
            double tableWidth = double.Parse(Console.ReadLine());

            double tableArea = (tableLength + (2 * 0.30)) * (tableWidth + (2 * 0.30));
            double carArea = tables * (tableWidth / 2) * (tableWidth / 2);

            double costUSD = tableArea * 7 + carArea * 9;
            double costBGN = costUSD * 1.85;

            Console.WriteLine(costUSD);
            Console.WriteLine(costBGN);

        }
    }
}
