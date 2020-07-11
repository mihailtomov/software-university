using System;

namespace _10._Top_Number
{
    class Program
    {
        public static void Main(string[] args)
        {
            string range = Console.ReadLine();

            PrintTopNumberInRange(range);
        }

        static void PrintTopNumberInRange(string range)
        {
            for (int current = 1; current <= int.Parse(range); current++)
            {
                int currentSum = 0;
                bool hasOddDigit = false;

                for (int index = 0; index < current.ToString().Length; index++)
                {
                    currentSum += current.ToString()[index];

                    if (current.ToString()[index] % 2 != 0)
                    {
                        hasOddDigit = true;
                    }
                }

                if (hasOddDigit && currentSum % 8 == 0)
                {
                    Console.WriteLine(current);
                }
            }
        }
    }
}
