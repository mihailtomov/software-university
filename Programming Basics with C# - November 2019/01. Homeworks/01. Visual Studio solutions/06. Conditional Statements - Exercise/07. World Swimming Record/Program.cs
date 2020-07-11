using System;

namespace _07._World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {
            double worldRecord = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double totalSeconds = distanceMeters * secondsPerMeter;
            double delaySeconds = Math.Floor(distanceMeters / 15);
            double totalDelay = delaySeconds * 12.5;
           


            double totalSecondsNeeded = totalSeconds + totalDelay;
            double secondsSlower = totalSecondsNeeded - worldRecord;

            if (totalSecondsNeeded < worldRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalSecondsNeeded:F2} seconds.");
            }

            else
            {
                Console.WriteLine($"No, he failed! He was {secondsSlower:F2} seconds slower.");
            }
        }
    }
}
