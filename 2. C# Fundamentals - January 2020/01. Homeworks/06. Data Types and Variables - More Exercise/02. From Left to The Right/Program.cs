using System;

namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] numbers = Console.ReadLine().Split();

                string leftNum = numbers[0];
                string rightNum = numbers[1];

                int sumOfLeftNum = 0;
                int sumOfRightNum = 0;

                for (int j = 0; j < leftNum.Length; j++)
                {
                    if (leftNum[0].ToString() == "-" && j < leftNum.Length - 1)
                    {
                        sumOfLeftNum += int.Parse(leftNum[j + 1].ToString());
                    }

                    if (leftNum[0].ToString() != "-")
                    {
                        sumOfLeftNum += int.Parse(leftNum[j].ToString());
                    }
                }

                for (int k = 0; k < rightNum.Length; k++)
                {
                    if (rightNum[0].ToString() == "-" && k < rightNum.Length - 1)
                    {
                        sumOfRightNum += int.Parse(rightNum[k + 1].ToString());
                    }

                    if (rightNum[0].ToString() != "-")
                    {
                        sumOfRightNum += int.Parse(rightNum[k].ToString());
                    }
                }

                if (decimal.Parse(leftNum) > decimal.Parse(rightNum))
                {
                    Console.WriteLine(sumOfLeftNum);
                }

                else
                {
                    Console.WriteLine(sumOfRightNum);
                }
            }
        }
    }
}
