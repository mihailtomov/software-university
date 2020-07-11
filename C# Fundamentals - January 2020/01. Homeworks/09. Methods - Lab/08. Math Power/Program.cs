using System;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = PowerOfNumber(number, power);
            Console.WriteLine(result);
        }

        static double PowerOfNumber(double num, int pow)
        {
            if (pow > 0)
            {
                double result = num;

                for (int i = 1; i < pow; i++)
                {
                    result *= num;
                }

                return result;
            }
            else
            {
                return 1;
            }
        }
    }
}
