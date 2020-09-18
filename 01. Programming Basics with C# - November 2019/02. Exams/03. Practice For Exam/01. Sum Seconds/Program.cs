using System;

namespace _01._Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int runnerOne = int.Parse(Console.ReadLine());
            int runnerTwo = int.Parse(Console.ReadLine());
            int runnerThree = int.Parse(Console.ReadLine());

            int totalTimeSeconds = runnerOne + runnerTwo + runnerThree;

            int hours = 0;
            int minutes = 0;

            if (totalTimeSeconds < 60)
            {
                hours = 0;
                minutes = totalTimeSeconds % 60;
            }

            else
            {
                hours = totalTimeSeconds / 60;
                minutes = totalTimeSeconds % 60;
            }

            Console.WriteLine($"{hours}:{minutes:d2}");
        }
    }
}
