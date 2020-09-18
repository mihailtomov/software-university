using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployee = int.Parse(Console.ReadLine());
            int secondEmployee = int.Parse(Console.ReadLine());
            int thirdEmployee = int.Parse(Console.ReadLine());

            int totalPeopleCount = int.Parse(Console.ReadLine());

            int answersPerHour = firstEmployee + secondEmployee + thirdEmployee;
            int totalAnswers = 0;
            int timeNeeded = 0;

            while (totalAnswers < totalPeopleCount)
            {
                timeNeeded++;

                if (timeNeeded % 4 != 0)
                {
                    totalAnswers += answersPerHour;
                }

                else
                {
                    totalAnswers += 0;
                }
            }

            Console.WriteLine($"Time needed: {timeNeeded}h.");
        }
    }
}
