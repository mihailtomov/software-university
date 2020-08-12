using System;

namespace _07._Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string student = Console.ReadLine();
            int counter = 1;
            double total = 0.0;

            while (counter <= 12)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 4.00)
                {
                    total = total + grade;
                    counter++;
                }
            }

            double average = total / 12;

            Console.WriteLine($"{student} graduated. Average grade: {average:F2}");
        }
    }
}
