using System;

namespace _05._Max_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int numCount = int.Parse(Console.ReadLine());
            int counter = 0;
            int max = int.MinValue;

            while (numCount > 0 && counter < numCount)
            {
                int number = int.Parse(Console.ReadLine());
                counter++;

                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine(max);
        }
    }
}
