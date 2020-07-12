using System;

namespace P05DateModifier
{
    public class DateModifier
    {
        public void CalculateDaysDifference(string date1, string date2)
        {
            DateTime firstDate = DateTime.Parse(date1);
            DateTime secondDate = DateTime.Parse(date2);

            Console.WriteLine(Math.Abs((firstDate - secondDate).TotalDays));
        }
    }
}
