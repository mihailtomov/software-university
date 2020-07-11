using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        public static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            CharactersInBetween(firstChar, secondChar);
        }

        static void CharactersInBetween(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                for (int i = secondChar + 1; i < firstChar; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }

            else
            {
                for (int i = firstChar + 1; i < secondChar; i++)
                {
                    Console.Write($"{(char)i} ");
                }
            }
        }
    }
}
