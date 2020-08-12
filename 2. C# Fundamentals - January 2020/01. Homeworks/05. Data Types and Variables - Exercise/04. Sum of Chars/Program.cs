using System;

namespace _04._Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLetters = int.Parse(Console.ReadLine());
            int charSum = 0;

            for (int i = 0; i < numberOfLetters; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                charSum += currentLetter;
            }

            Console.WriteLine($"The sum equals: {charSum}");
        }
    }
}
