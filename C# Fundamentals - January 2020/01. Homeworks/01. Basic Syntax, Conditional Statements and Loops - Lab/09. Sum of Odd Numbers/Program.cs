using System;

namespace _09._Sum_of_Odd_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfOddNumbers = 0;
            int currentNumber = 1;

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(currentNumber);
                sumOfOddNumbers += currentNumber;
                currentNumber += 2;
            }

            Console.WriteLine($"Sum: {sumOfOddNumbers}");
        }
    }
}
