using System;

namespace _09._Numbers_N._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i < number; i+=3)
            {
                Console.WriteLine(i);
            }
        }
    }
}
