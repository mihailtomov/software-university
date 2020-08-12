using System;

namespace _02._Repeat_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                string currWord = input[i];
                int currWordLength = currWord.Length;

                for (int j = 0; j < currWordLength; j++)
                {
                    Console.Write($"{currWord}");
                }
            }

            Console.WriteLine();
        }
    }
}
