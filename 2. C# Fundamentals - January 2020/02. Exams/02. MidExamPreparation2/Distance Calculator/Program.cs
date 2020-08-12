using System;

namespace Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSteps = int.Parse(Console.ReadLine());
            double oneStepInCentimeters = double.Parse(Console.ReadLine());
            int distanceInMeters = int.Parse(Console.ReadLine());

            double totalDistanceInCentimeters = totalSteps * oneStepInCentimeters;

            double everyFifhStep = 0.30 * oneStepInCentimeters;

            for (int i = 5; i <= totalSteps; i += 5)
            {
                totalDistanceInCentimeters -= everyFifhStep;
            }

            double totalDistanceInMeters = totalDistanceInCentimeters / 100;

            double percentage = totalDistanceInMeters / distanceInMeters * 100;

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}
