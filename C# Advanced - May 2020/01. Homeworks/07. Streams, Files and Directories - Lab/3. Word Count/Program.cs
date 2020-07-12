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
            string textPath = Path.Combine("Data", "text.txt");
            string wordsPath = Path.Combine("Data", "words.txt");

            Dictionary<string, int> word = new Dictionary<string, int>();
            StreamReader wordsReader = new StreamReader(wordsPath);

            using (wordsReader)
            {
                string line = wordsReader.ReadLine();
                string[] words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; i++)
                {
                    word[words[i]] = 0;
                }

                StreamReader textReader = new StreamReader(textPath);

                using (textReader)
                {
                    char[] separators = { ' ', '.', ',', '?', '!', '-' };
                    string[] text = textReader.ReadToEnd()
                        .ToLower()
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < text.Length; i++)
                    {
                        if (word.ContainsKey(text[i]))
                        {
                            word[text[i]]++;
                        }
                    }

                    StreamWriter writer = new StreamWriter("Output.txt");

                    using (writer)
                    {
                        word = word
                            .OrderByDescending(kvp => kvp.Value)
                            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                        foreach (var kvp in word)
                        {
                            string wordToWrite = kvp.Key;
                            int count = kvp.Value;

                            writer.WriteLine($"{wordToWrite} - {count}");
                        }
                    }
                }
            }
        }
    }
}
