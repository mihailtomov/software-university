using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string textNumber = number.ToString();
            int currentNum = 0;
            int currentFactorialSum = 0;
            int totalFactorialSum = 0;


            for (int i = 0; i < textNumber.Length; i++)
            {

                currentNum = int.Parse(textNumber[i].ToString());
                int currentMultiplier = currentNum;

                if (currentNum == 0 || currentNum == 1)
                {
                    currentFactorialSum = 1;
                }

                for (int j = currentNum - 1; j > 0; j--)
                {
                    currentFactorialSum = currentMultiplier * j;
                    currentMultiplier += currentMultiplier * j - currentMultiplier;
                }

                totalFactorialSum += currentFactorialSum;
                currentFactorialSum = 0;
            }

            if (number == totalFactorialSum)
            {
                Console.WriteLine("yes");
            }

            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
