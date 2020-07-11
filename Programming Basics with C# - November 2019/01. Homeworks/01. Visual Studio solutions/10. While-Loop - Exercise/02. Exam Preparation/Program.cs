using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int failedThreshold = int.Parse(Console.ReadLine());

            int failedTimes = 0;
            int solvedProblemsCount = 0;
            double gradesSum = 0.0;
            string lastProblem = "";
            bool isFailed = true;

            while (failedTimes < failedThreshold)
            {
                string exerciseName = Console.ReadLine();
                int exerciseGrade = int.Parse(Console.ReadLine());

                gradesSum += exerciseGrade;
                solvedProblemsCount++;
                lastProblem = exerciseName;

                if (true)
                {

                }
            }


        }
    }
}
