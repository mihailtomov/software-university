using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. >= 10 000
            // 2. Going home

            string input = Console.ReadLine();

            int totalSteps = 0;

            while (input != "Going home")
            {
                totalSteps += int.Parse(input);
                input = Console.ReadLine();
            }
        }
    }
}
