using System;

namespace _08._Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double levaIncome = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minimalWage = double.Parse(Console.ReadLine());

            double socialScholarship = 0.35 * minimalWage;
            double gradeScholarship = averageGrade * 25;

            if (levaIncome < minimalWage && averageGrade > 4.5 && averageGrade < 5.50)
            {
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }
          
            else if (levaIncome < minimalWage && averageGrade >= 5.50 && gradeScholarship >= socialScholarship)

            { 
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship)} BGN");
            }

            else if (levaIncome < minimalWage && averageGrade >= 5.50 && gradeScholarship < socialScholarship)
                
            {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }

            else if (averageGrade >= 5.50)
            {
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(gradeScholarship)} BGN");
            }

            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
