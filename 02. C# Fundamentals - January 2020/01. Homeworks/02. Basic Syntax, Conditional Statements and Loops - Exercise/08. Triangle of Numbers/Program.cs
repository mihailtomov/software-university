using System;

namespace _08._Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentNumber = 0;

            for (int i = 1; i <= n; i++)
            {
                currentNumber = i;
                for (int j = 1; j <= i; j++)
                {
                    Console.Write($"{currentNumber} ");
                }

                Console.WriteLine();
            }
        }
    }
}
