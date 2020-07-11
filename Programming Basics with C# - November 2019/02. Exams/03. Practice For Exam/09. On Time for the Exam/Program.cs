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

            int examTimeMinutes = examHour * 60 + examMinutes;
            int arrivalTimeMinutes = arrivalHour * 60 + arrivalMinutes;

            int diffEarly = examTimeMinutes - arrivalTimeMinutes;
            int diffLate = arrivalTimeMinutes - examTimeMinutes;

            int hours = 0;
            int minutes = 0;


            if (diffLate > 0)
            {
                if (diffLate < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{diffLate} minutes after the start");
                }

                else
                {
                    hours = diffLate / 60;
                    minutes = diffLate % 60;
                    Console.WriteLine("Late");
                    Console.WriteLine($"{hours}:{minutes:d2} hours after the start");
                }
                
            }

            if (diffEarly <= 30 && diffEarly >= 0)
            {
                if (diffEarly != 0)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{diffEarly} minutes before the start");
                }

                else
                {
                    Console.WriteLine("On time");
                }
            }

            if (diffEarly > 30)
            {
                if (diffEarly < 60)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{diffEarly} minutes before the start");
                }

                else
                {
                    hours = Math.Abs(diffLate / 60);
                    minutes = Math.Abs(diffLate % 60);
                    Console.WriteLine("Early");
                    Console.WriteLine($"{hours}:{minutes:d2} hours before the start");
                }
            }
        }
    }
}
