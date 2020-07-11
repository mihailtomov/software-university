using System;

namespace _02._Vowels_Count
{
    class Program
    {
        public static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int result = CountOfVowels(word);
            Console.WriteLine(result);
        }

        static int CountOfVowels(string word)
        {
            int vowelsCount = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u' || word[i] == 'i')
                {
                    vowelsCount++;
                }
            }

            return vowelsCount;
        }
    }
}
