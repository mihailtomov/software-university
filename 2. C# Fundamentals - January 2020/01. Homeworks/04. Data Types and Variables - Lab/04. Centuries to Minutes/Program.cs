using System;

namespace _04._Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int centuriesNum = int.Parse(Console.ReadLine());

            byte centuriesCount = (byte)centuriesNum;
            ushort yearsCount = (ushort)(centuriesNum * 100);
            decimal daysCount = (ulong)(yearsCount * 365.2422m);
            ulong hoursCount = (ulong)daysCount * 24;
            ulong minutesCount = hoursCount * 60;

            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes", centuriesCount, yearsCount, daysCount, hoursCount, minutesCount);
        }
    }
}
