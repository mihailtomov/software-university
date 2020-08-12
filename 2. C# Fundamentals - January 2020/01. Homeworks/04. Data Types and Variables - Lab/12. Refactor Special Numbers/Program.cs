using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int current = 1; current <= n; current++)
            {
                int temp = 0;
                temp = current;
                int sumOfNums = 0;

                while (current > 0)
                {
                    sumOfNums += current % 10;
                    current = current / 10;
                }

                bool isSpecialNum = false;
                isSpecialNum = (sumOfNums == 5) || (sumOfNums == 7) || (sumOfNums == 11);
                Console.WriteLine("{0} -> {1}", temp, isSpecialNum);
                current = temp;
            }
        }
    }
}
