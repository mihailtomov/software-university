using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbersCount = int.Parse(Console.ReadLine());
            decimal numbersSum = 0m;

            for (int i = 0; i < numbersCount; i++)
            {
                decimal currentNum = decimal.Parse(Console.ReadLine());
                numbersSum += currentNum;
            }

            Console.WriteLine(numbersSum);
        }
    }
}
