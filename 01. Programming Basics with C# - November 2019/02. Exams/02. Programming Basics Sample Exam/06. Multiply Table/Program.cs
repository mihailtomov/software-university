using System;

namespace _06._Multiply_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int num1 = num % 10;
            int num2 = num / 10 % 10;
            int num3 = num / 10 / 10 % 10;

            for (int i = 1; i <= num1; i++)
            {
                for (int j = 1; j <= num2; j++)
                {
                    for (int k = 1; k <= num3; k++)
                    {
                        int product = i * j * k;
                        Console.WriteLine($"{i} * {j} * {k} = {product};");
                    }
                }
            }
        }
    }
}
