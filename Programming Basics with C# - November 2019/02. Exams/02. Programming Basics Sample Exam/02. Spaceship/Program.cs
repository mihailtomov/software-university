using System;

namespace _02._Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double spaceshipWidth = double.Parse(Console.ReadLine());
            double spaceshipLength = double.Parse(Console.ReadLine());
            double spaceshipHeight = double.Parse(Console.ReadLine());
            double averageAstrounatHeight = double.Parse(Console.ReadLine());

            double roomSizePerRoom = (averageAstrounatHeight + 0.40) * 2 * 2;
            double spaceshipSize = spaceshipWidth * spaceshipLength * spaceshipHeight;

            double astronautCount = Math.Floor(spaceshipSize / roomSizePerRoom);

            if (astronautCount >= 3 && astronautCount <= 10)
            {
                Console.WriteLine($"The spacecraft holds {astronautCount} astronauts.");
            }

            else if (astronautCount < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }

            else
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}
