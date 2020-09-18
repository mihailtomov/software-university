using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordDescriptionPairs = Console.ReadLine();
            string wordsToCheck = Console.ReadLine();
            string command = Console.ReadLine();

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

            string[] splittedWords = wordDescriptionPairs.Split(" | ");

            for (int i = 0; i < splittedWords.Length; i++)
            {
                string pair = splittedWords[i];
                string[] splittedPair = pair.Split(": ");

                string currWord = splittedPair[0];
                string currDefinition = splittedPair[1];

                if (!dictionary.ContainsKey(currWord))
                {
                    dictionary[currWord] = new List<string>();
                    dictionary[currWord].Add(currDefinition);
                }
                else
                {
                    dictionary[currWord].Add(currDefinition);
                }
            }

            string[] splittedWordsToCheck = wordsToCheck.Split(" | ");

            for (int i = 0; i < splittedWordsToCheck.Length; i++)
            {
                string currWordToCheck = splittedWordsToCheck[i];

                if (dictionary.ContainsKey(currWordToCheck))
                {
                    Console.WriteLine($"{currWordToCheck}");

                    dictionary[currWordToCheck] = dictionary[currWordToCheck]
                        .OrderByDescending(item => item.Length)
                        .ToList();

                    foreach (var definition in dictionary[currWordToCheck])
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }

            if (command == "End")
            {
                return;
            }
            else
            {
                dictionary = dictionary
                    .OrderBy(kvp => kvp.Key)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                Console.WriteLine($"{string.Join(" ", dictionary.Keys)}");
            }
        }
    }
}
