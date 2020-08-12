using System;
using System.Linq;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] date = Console.ReadLine().Split('-').Select(int.Parse).ToArray();

            DateTime day = new DateTime(date[2], date[1], date[0]);

            Console.WriteLine(day.DayOfWeek);
        }
    }
}
