using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Dictionary<char, uint> charCount = new Dictionary<char, uint>();

            for (int i = 0; i < words.Length; i++)
            {
                char currChar = words[i];

                if (currChar != ' ' && !charCount.ContainsKey(currChar))
                {
                    charCount[currChar] = 0;
                }

                if (currChar != ' ')
                {
                    charCount[currChar]++;
                }
            }

            foreach (var kvp in charCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
