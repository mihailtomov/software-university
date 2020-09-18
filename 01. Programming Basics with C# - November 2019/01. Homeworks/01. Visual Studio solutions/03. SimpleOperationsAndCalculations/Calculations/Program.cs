using System;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = Math.Round(5.0, 2);
            Console.WriteLine(number);
            Console.WriteLine("{0:F2}" , 5);
        }
    }
}
