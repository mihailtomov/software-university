using System;

namespace P05DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            var dateModifier = new DateModifier();
            dateModifier.CalculateDaysDifference(firstDate, secondDate);
        }
    }
}
