using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int givenNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = i + 1; k < numbers.Length; k++)
                {
                    int currentPairSum = numbers[i] + numbers[k];

                    if (currentPairSum == givenNumber)
                    {
                        Console.Write($"{numbers[i]} {numbers[k]}");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
