using System;

namespace _08._Graduation_pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string student = Console.ReadLine();
            int counter = 1;
            double total = 0.0;

            double excluded = 0.0;
            bool isExcluded = false;

            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4.00)
                {
                    excluded++;
                }

                else if (grade >= 4.00)
                {
                    total += grade;
                    counter++;
                }

                if (excluded >= 2)
                {
                    isExcluded = true;
                    break;
                }
            }

            if (isExcluded)
            {
                Console.WriteLine($"{student} has been excluded at {counter} grade");
            }
            
            else
            {
                double averageGrade = total / 12;
                Console.WriteLine($"{student} graduated. Average grade: {averageGrade:F2}");
            }  
        }
    }
}
