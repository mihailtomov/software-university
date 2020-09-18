using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            string[] text = File.ReadAllLines("text.txt");

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                wordCount[word] = 0;
            }

            for (int i = 0; i < text.Length; i++)
            {
                string line = text[i];

                string[] wordsToCheck = line
                    .ToLower()
                    .Split(new string[] { " ", "-", ",", ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsToCheck)
                {
                    if (wordCount.ContainsKey(word))
                    {
                        wordCount[word]++;
                    }
                }
            }

            wordCount = wordCount
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            using StreamWriter writer = new StreamWriter("actualResults.txt");

            foreach (var kvp in wordCount)
            {
                string word = kvp.Key;
                int count = kvp.Value;

                writer.WriteLine($"{word} - {count}");
            }
        }
    }
}
