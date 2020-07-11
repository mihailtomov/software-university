using System;

namespace _03._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int currentNum = firstNum; currentNum < secondNum; currentNum++)
            {
                int evenSum = 0;
                int oddSum = 0;
                string current = currentNum.ToString();

                for (int i = 0; i < current.Length; i++)
                {
                    char currentDigit = current[i];
                    if (i % 2 != 0)
                    {
                        evenSum += int.Parse(currentDigit.ToString());
                    }

                    else
                    {
                        oddSum += int.Parse(currentDigit.ToString());
                    }
                }

                if (evenSum == oddSum)
                {
                    Console.WriteLine(current + " ");
                }
            }
        }
    }
}
