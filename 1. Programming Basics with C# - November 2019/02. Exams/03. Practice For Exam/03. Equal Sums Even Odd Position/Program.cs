using System;

namespace _03._Equal_Sums_Even_Odd_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            int Num1 = int.Parse(Console.ReadLine());
            int Num2 = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;

            for (int i = Num1; i <= Num2; i++)
            {
                string toStringNum = i.ToString();

                for (int j = 0; j < toStringNum.Length; j++)
                {
                    int current = int.Parse(toStringNum[j].ToString());

                    if (j == 0 || j == 2 || j == 4)
                    {
                        oddSum += current;
                    }

                    else
                    {
                        evenSum += current;
                    }
                }

                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");
                }

                oddSum = 0;
                evenSum = 0;
            }
        }
    }
}
