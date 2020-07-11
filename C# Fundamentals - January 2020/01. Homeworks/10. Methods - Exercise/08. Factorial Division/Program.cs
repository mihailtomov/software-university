using System;

namespace _08._Factorial_Division
{
    class Program
    {
        public static void Main(string[] args)
        {
            decimal firstNum = decimal.Parse(Console.ReadLine());
            decimal secondNum = decimal.Parse(Console.ReadLine());

            GetFactorialOfNumber(firstNum);
            GetFactorialOfNumber(secondNum);

            decimal result = GetFactorialOfNumber(firstNum) / GetFactorialOfNumber(secondNum);

            Console.WriteLine($"{result:f2}");
        }

        static decimal GetFactorialOfNumber(decimal num)
        {
            decimal multiplier = num - 1;
            decimal currentSum = 0;

            while (multiplier >= 1 && num != 0 && num != 1)
            {
                currentSum = num * multiplier;
                num = currentSum;
                multiplier -= 1;
            }

            if (num == 1 || num == 0)
            {
                currentSum = 1;
            }

            return currentSum;
        }
    }
}
