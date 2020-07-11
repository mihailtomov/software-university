using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        public static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            Console.WriteLine(PrintSmallestOfThreeNums(firstNum, secondNum, thirdNum));
        }

        static int PrintSmallestOfThreeNums(int num1, int num2, int num3)
        {
            int smallest = 0;

            if (num1 <= num2 && num1 <= num3)
            {
                smallest = num1;
            }

            else if (num2 <= num1 && num2 <= num3)
            {
                smallest = num2;
            }

            else
            {
                smallest = num3;
            }

            return smallest;
        }
    }
}
