using System;

namespace _09._Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int availableSpace = width * length * height;

            int totalBoxCount = 0;
            string input = Console.ReadLine();

            while (input != "Done")
            {
                int currentBoxes = int.Parse(input);
                totalBoxCount += currentBoxes;

                if (totalBoxCount > availableSpace)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            int freeSpace = availableSpace - totalBoxCount;
            int notEnough = totalBoxCount - availableSpace;

            if (input == "Done" && availableSpace > totalBoxCount)
            {
                Console.WriteLine($"{freeSpace} Cubic meters left.");
            }

            else
            {
                Console.WriteLine($"No more free space! You need {notEnough} Cubic meters more.");
            }
        }
    }
}
