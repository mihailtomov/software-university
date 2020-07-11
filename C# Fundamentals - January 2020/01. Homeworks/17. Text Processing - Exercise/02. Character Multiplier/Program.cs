using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string str1 = input[0];
            string str2 = input[1];

            string leftover;
            int startIndex;

            int totalSum = 0;

            if (str1.Length > str2.Length)
            {
                startIndex = str2.Length;
                leftover = str1.Substring(startIndex);

                for (int i = 0; i < str2.Length; i++)
                {
                    totalSum += str1[i] * str2[i];
                }

                for (int i = 0; i < leftover.Length; i++)
                {
                    totalSum += leftover[i];
                }
            }

            else if (str1.Length < str2.Length)
            {
                startIndex = str1.Length;
                leftover = str2.Substring(startIndex);

                for (int i = 0; i < str1.Length; i++)
                {
                    totalSum += str1[i] * str2[i];
                }

                for (int i = 0; i < leftover.Length; i++)
                {
                    totalSum += leftover[i];
                }
            }

            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    totalSum += str1[i] * str2[i];
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}
