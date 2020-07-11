using System;

namespace _01._Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int battlesCount = int.Parse(Console.ReadLine());

            double totalExperience = 0;
            int battlesNeeded = 0;
            bool isEnough = false;

            for (int i = 1; i <= battlesCount; i++)
            {
                double experiencePerBattle = double.Parse(Console.ReadLine());

                battlesNeeded++;

                if (i % 3 == 0)
                {
                    totalExperience += 1.15 * experiencePerBattle;
                }

                else if (i % 5 == 0)
                {
                    totalExperience += 0.90 * experiencePerBattle;
                }

                else
                {
                    totalExperience += experiencePerBattle;
                }

                if (totalExperience >= neededExperience)
                {
                    isEnough = true;
                    break;
                }
            }

            double experienceLess = neededExperience - totalExperience;

            if (isEnough == true)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battlesNeeded} battles.");
            }

            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {experienceLess:f2} more needed.");
            }
        }
    }
}
