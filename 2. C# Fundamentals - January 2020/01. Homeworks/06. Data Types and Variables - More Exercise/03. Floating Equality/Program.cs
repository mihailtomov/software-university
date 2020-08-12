using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            double diff = 0;

            if (firstNum > secondNum)
            {
                diff = firstNum - secondNum;
            }

            else if (secondNum > firstNum)
            {
                diff = secondNum - firstNum;
            }

            else
            {
                diff = 0;
            }

            if (diff >= 0.000001)
            {
                Console.WriteLine("False");
            }

            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
