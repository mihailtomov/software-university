using System;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstString = Console.ReadLine().ToLower();
            string secondString = Console.ReadLine().ToLower();

            while (secondString.Contains(firstString))
            {
                int indexOfWord = secondString.IndexOf(firstString);
                string tempWord = secondString.Remove(indexOfWord, firstString.Length);

                secondString = tempWord;
            }

            Console.WriteLine(secondString);
        }
    }
}
