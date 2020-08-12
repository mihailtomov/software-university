using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(@|#)(?<firstword>[A-Za-z]{3,})\1\1(?<secondword>[A-Za-z]{3,})\1";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                List<string> mirrorWordsList = new List<string>();

                foreach (Match match in matches)
                {
                    string currFirstWord = match.Groups["firstword"].Value;
                    string currSecondWord = match.Groups["secondword"].Value;

                    StringBuilder backwards = new StringBuilder();

                    for (int i = currSecondWord.Length - 1; i >= 0; i--)
                    {
                        backwards.Append(currSecondWord[i]);
                    }

                    string mirrorWords = "";

                    if (currFirstWord == backwards.ToString())
                    {
                        mirrorWords += currFirstWord + " <=> " + currSecondWord;
                        mirrorWordsList.Add(mirrorWords);
                    }
                }

                if (mirrorWordsList.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(String.Join(", ", mirrorWordsList));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
