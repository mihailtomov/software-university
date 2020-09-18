using System;

namespace _09._On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());

            int timeOfExamMinutes = (examHour * 60) + examMinutes;
            int timeOfArrivalMinutes = (arrivalHour * 60) + arrivalMinutes;

            if (timeOfArrivalMinutes > timeOfExamMinutes)
            {
                Console.WriteLine("Late");
            }

            if (timeOfArrivalMinutes - 30 <= timeOfExamMinutes)
            {
                Console.WriteLine("On time");
            }

            else if (timeOfArrivalMinutes - 30 < timeOfExamMinutes)
            {
                Console.WriteLine("Early");
            }

        }
    }
}
