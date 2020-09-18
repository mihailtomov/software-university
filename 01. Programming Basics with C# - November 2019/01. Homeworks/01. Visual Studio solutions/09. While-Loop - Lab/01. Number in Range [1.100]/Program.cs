using System;

namespace _01._Number_in_Range__1._100_
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            while (n > 100 || n < 1)
            {
                Console.WriteLine("Invalid number!");
                n = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"The number is: {n}");
        }
    }
}
