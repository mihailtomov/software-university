using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([:]{2}|[*]{2})[A-Z][a-z]{2,}\1";

            string input = Console.ReadLine();

            BigInteger coolThresholdSum = 0;

            List<string> digitsFromInput = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                char currCh = input[i];

                if (Char.IsDigit(currCh))
                {
                    digitsFromInput.Add(currCh.ToString());
                }
            }

            coolThresholdSum += int.Parse(digitsFromInput[0]);

            for (int i = 1; i < digitsFromInput.Count; i++)
            {
                int currDigit = int.Parse(digitsFromInput[i]);
                coolThresholdSum = coolThresholdSum * currDigit;
            }

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matches)
            {
                string currValidEmoji = match.Groups[0].Value;
                int currEmojiCoolness = 0;

                for (int i = 0; i < currValidEmoji.Length; i++)
                {
                    char currCh = currValidEmoji[i];

                    if (Char.IsLetter(currCh))
                    {
                        int currChValue = currCh;
                        currEmojiCoolness += currChValue;
                    }
                }

                if (currEmojiCoolness > coolThresholdSum)
                {
                    Console.WriteLine($"{currValidEmoji}");
                }
            }
        }
    }
}
