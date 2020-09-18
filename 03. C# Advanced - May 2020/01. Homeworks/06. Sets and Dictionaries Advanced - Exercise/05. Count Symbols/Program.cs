using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (!chars.ContainsKey(ch))
                {
                    chars[ch] = 1;
                }
                else
                {
                    chars[ch]++;
                }
            }

            foreach (var ch in chars)
            {
                char currCh = ch.Key;
                int count = ch.Value;

                Console.WriteLine($"{currCh}: {count} time/s");
            }
        }
    }
}
