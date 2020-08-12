using System;

namespace _04._Refactoring_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            for (int currNum = 2; currNum <= range; currNum++)
            {
                string isPrime = "true";

                for (int divider = 2; divider < currNum; divider++)
                {
                    if (currNum % divider == 0)
                    {
                        isPrime = "false";
                        break;
                    }
                }
                Console.WriteLine("{0} -> {1}", currNum, isPrime);
            }
        }
    }
}
