using System;

namespace _02._Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            PrintGradeInWords(grade);
        }

        static void PrintGradeInWords(double input)
        {
            if (input >= 2.00 && input < 3.00)
            {
                Console.WriteLine("Fail");
            }
            else if (input >= 3.00 && input < 3.50)
            {
                Console.WriteLine("Poor");
            }
            else if (input >= 3.50 && input < 4.50)
            {
                Console.WriteLine("Good");
            }
            else if (input >= 4.50 && input < 5.50)
            {
                Console.WriteLine("Very good");
            }
            else
            {
                Console.WriteLine("Excellent");
            }
        }
    }
}
