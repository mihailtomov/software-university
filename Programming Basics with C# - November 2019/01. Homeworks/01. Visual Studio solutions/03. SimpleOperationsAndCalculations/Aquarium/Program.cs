using System;

namespace Aquarium
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentInput = double.Parse(Console.ReadLine());
            double percent = percentInput * 0.01;

            double totalVolume = (length * width * height) / 1000;
            double usedVolume = totalVolume * percent;

            double result = totalVolume - usedVolume;

            Console.WriteLine("{0:F3}", result);
        }
    }
}
